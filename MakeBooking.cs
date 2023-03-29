using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using TravelAgent.BusinessTier;

namespace TravelAgent
{
    public partial class MakeBooking : Form
    {
        public BusinessClass myBusinessClass { get; set; }

        HttpClient aerLingusClient = new HttpClient();
        HttpClient ryanairClient = new HttpClient();
        HttpClient bookingClient = new HttpClient();
        HttpClient paymentClient = new HttpClient();

        string selectedCarrier = "";
        string selectedDepartureRef = "";
        decimal selectedDeparturePrice = 0;
        string selectedReturnRef = "";
        decimal selectedReturnPrice = 0;
        decimal selectedTotalPrice = 0;

        public MakeBooking()
        {
            InitializeComponent();

            pnlBookingHeader.Visible = false;
            pnlBookingDetails.Visible = false;

            aerLingusClient.BaseAddress = new Uri("https://localhost:44387");
            ryanairClient.BaseAddress = new Uri("https://localhost:44354");
            paymentClient.BaseAddress = new Uri("https://localhost:44386");
        }

        private async void btnSearchFlights_Click(object sender, EventArgs e)
        {
            try
            {
                // myBusinessClass = new BusinessClass();

                //to format Departure date & Arrival date in date-only format: '01-Apr-2023'
                string depDate = dtDeparture.Value.ToString("dd-MMM-yyyy");
                string retDate = dtReturn.Value.ToString("dd-MMM-yyyy");


                /////////////// Aer Lingus - Retrieve Flights ///////////////

                HttpResponseMessage aerLingusResult;
                string aerLingusContent;

                //Retrieve Aer Lingus flights for departure
                aerLingusResult = await aerLingusClient.GetAsync("ListFlights/Get/" + depDate);
                aerLingusContent = await aerLingusResult.Content.ReadAsStringAsync();

                //Add to empty list for display in grid
                List<Flight> availableFlights = JsonConvert.DeserializeObject<List<Flight>>(aerLingusContent);

                //Retrieve Aer Lingus flights for return
                aerLingusResult = await aerLingusClient.GetAsync("ListFlights/Get/" + retDate);
                aerLingusContent = await aerLingusResult.Content.ReadAsStringAsync();

                //Add to empty list for display in grid
                List<Flight> returnFlights = JsonConvert.DeserializeObject<List<Flight>>(aerLingusContent);


                ///////////////   Ryanair - Retrieve Flights  ///////////////

                HttpResponseMessage ryanairResult;
                string ryanairContent;

                //Retrieve Ryanair flights for departure
                ryanairResult = await ryanairClient.GetAsync("ListFlights/Get/" + depDate);
                ryanairContent = await ryanairResult.Content.ReadAsStringAsync();

                //add Ryanair flights to existing departures list (single list for both airlines)
                availableFlights.AddRange(JsonConvert.DeserializeObject<List<Flight>>(ryanairContent));

                //Retrieve Ryanair flights for departure
                ryanairResult = await ryanairClient.GetAsync("ListFlights/Get/" + retDate);
                ryanairContent = await ryanairResult.Content.ReadAsStringAsync();

                //add Ryanair flights to existing arrivals list (single list for both airlines)
                returnFlights.AddRange(JsonConvert.DeserializeObject<List<Flight>>(ryanairContent));


                ///////////////           Sort Lists          ///////////////

                //sort list by departure date and bind to grid
                List<Flight> sortedFlights = availableFlights.OrderBy(x => x.Departure).ToList();
                dgvFlights.DataSource = sortedFlights;

                //sort list by return date and bind to grid
                List<Flight> sortedReturnFlights = returnFlights.OrderBy(x => x.Departure).ToList();
                dgvReturns.DataSource = sortedReturnFlights;

                //cosmetics
                SetCells();
            }
            catch (Exception e3)
            {
                MessageBox.Show(e3.Message);
            }
        }

        private void btnSelectFlights_Click(object sender, EventArgs e)
        {
            try
            {
                if ((dgvFlights.SelectedRows.Count == 1) && (dgvReturns.SelectedRows.Count == 1))
                {
                    if (dgvFlights.SelectedRows[0].Cells[0].Value.ToString() == dgvReturns.SelectedRows[0].Cells[0].Value.ToString()) //ensuring both flights are for same carrier
                    {
                        selectedCarrier = dgvFlights.SelectedRows[0].Cells[0].Value.ToString();
                        selectedDepartureRef = dgvFlights.SelectedRows[0].Cells[2].Value.ToString();
                        selectedDeparturePrice = (decimal)dgvFlights.SelectedRows[0].Cells[5].Value;
                        selectedReturnRef = dgvReturns.SelectedRows[0].Cells[2].Value.ToString();
                        selectedReturnPrice = (decimal)dgvReturns.SelectedRows[0].Cells[5].Value;
                        selectedTotalPrice = (decimal)dgvFlights.SelectedRows[0].Cells[5].Value + (decimal)dgvReturns.SelectedRows[0].Cells[5].Value;
                        txtPrice.Text = selectedTotalPrice.ToString("F2");
                        pnlBookingHeader.Visible = true;
                        pnlBookingDetails.Visible = true;
                    }
                    else
                    {
                        MessageBox.Show("Outbound and Return Flights must use the same Airline");
                    }
                }
            }
            catch (Exception e2)
            {
                MessageBox.Show(e2.Message);
            }
        }

        private async void btnPay_Click(object sender, EventArgs e)
        {
            try
            {
                ByteArrayContent byteContent;

                HttpResponseMessage bookingResponse;
                string outwardBookingRef = "";
                string returnBookingRef = "";
                string bookingResult = "";
                int outwardRef = 0;
                int returnRef = 0;

                HttpResponseMessage paymentResponse;
                string paymentRef = "";

                //Assemble outward booking details
                Booking outwardBooking = AssembleBookingDetails();

                //Assemble return booking details
                Booking returnBooking = AssembleBookingDetails();

                //Assemble payment details
                Payment currentPayment = AssemblePaymentDetails();

                ////////////////////////////////////////////////////////////
                //Step 1: Create Bookings on Carrier System (2 for a return trip) - without Authorization Code - holds the bookings temporarily - only confirmed when Payment Ref is added
                ////////////////////////////////////////////////////////////

                //Post Outward Booking
                byteContent = new ByteArrayContent(System.Text.Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(outwardBooking)));
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                switch (selectedCarrier)
                {
                    case "Aer Lingus":
                        bookingResponse = await aerLingusClient.PostAsync("MakeBooking/Post/", byteContent);
                        break;
                    default:
                        bookingResponse = await ryanairClient.PostAsync("MakeBooking/Post/", byteContent);
                        break;
                }

                outwardBookingRef = await bookingResponse.Content.ReadAsStringAsync(); //outwardBookingRef will contain newly created ID on Booking Record for outward flight

                if (outwardBookingRef == "") { throw new HttpRequestException("Error: Failure making Outward Booking"); }

                //Post Return Booking
                byteContent = new ByteArrayContent(System.Text.Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(returnBooking)));
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                switch (selectedCarrier)
                {
                    case "Aer Lingus":
                        bookingResponse = await aerLingusClient.PostAsync("MakeBooking/Post/", byteContent);
                        break;
                    default:
                        bookingResponse = await ryanairClient.PostAsync("MakeBooking/Post/", byteContent);
                        break;
                }

                returnBookingRef = await bookingResponse.Content.ReadAsStringAsync(); //returnBookingRef will contain newly created ID on Booking Record for return flight

                if (returnBookingRef == "") { throw new HttpRequestException("Error: Failure making Return Booking"); }

                ////////////////////////////////////////////////////////////
                //Step 2: Create Payment record on VISA - if transaction fails then Carrier Booking will expire. If transaction succeeds then Payment Ref can be passed back to Carrier to commit transaction
                ////////////////////////////////////////////////////////////

                //Post Payment
                byteContent = new ByteArrayContent(System.Text.Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(currentPayment)));
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                paymentResponse = await paymentClient.PostAsync("MakePayment/Post/", byteContent);
                paymentRef = await paymentResponse.Content.ReadAsStringAsync(); //paymentRef will contain newly created ID on Payment Record

                if (paymentRef == "") { throw new HttpRequestException("Error: Failure making VISA Payment"); }

                ////////////////////////////////////////////////////////////
                //Step 3: Update Booking with Payment Ref (on Carrier System)
                ////////////////////////////////////////////////////////////

                if (paymentRef != "") //payment processed successfully
                {
                    //Update Outward Booking with Payment Ref
                    Confirmation outwardConfirmation = new Confirmation();
                    Int32.TryParse(outwardBookingRef, out outwardRef);
                    outwardConfirmation.BookingID = outwardRef;
                    outwardConfirmation.PayRef = "Ref: " + paymentRef;
                    byteContent = new ByteArrayContent(System.Text.Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(outwardConfirmation)));
                    byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                    switch (selectedCarrier)
                    {
                        case "Aer Lingus":
                            bookingResponse = await aerLingusClient.PostAsync("Confirmation/Post/", byteContent);
                            break;
                        default:
                            bookingResponse = await ryanairClient.PostAsync("Confirmation/Post/", byteContent);
                            break;
                    }

                    bookingResult = await bookingResponse.Content.ReadAsStringAsync();

                    if (bookingResult == "") { throw new HttpRequestException("Error: Failure updating Outbound Booking with Payment Reference "); }

                    //Update Return Booking with Payment Ref
                    Confirmation returnConfirmation = new Confirmation();
                    Int32.TryParse(returnBookingRef, out returnRef);
                    returnConfirmation.BookingID = returnRef;
                    returnConfirmation.PayRef = "Ref: " + paymentRef;
                    byteContent = new ByteArrayContent(System.Text.Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(returnConfirmation)));
                    byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                    switch (selectedCarrier)
                    {
                        case "Aer Lingus":
                            bookingResponse = await aerLingusClient.PostAsync("Confirmation/Post/", byteContent);
                            break;
                        default:
                            bookingResponse = await ryanairClient.PostAsync("Confirmation/Post/", byteContent);
                            break;
                    }

                    bookingResult = await bookingResponse.Content.ReadAsStringAsync();

                    if (bookingResult == "") { throw new HttpRequestException("Error: Failure updating Return Booking with Payment Reference "); }
                    
                    MessageBox.Show(" Booking Successful ");
                }
            }
            catch (HttpRequestException e10)
            {
                MessageBox.Show(e10.Message);
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
        }
        private void SetCells()
        {
            try
            {
                dgvFlights.Columns[1].Width = 60;
                dgvFlights.Columns[2].Width = 100;
                dgvFlights.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvFlights.Columns[3].Width = 200;
                dgvFlights.Columns[4].Width = 200;
                dgvFlights.Columns[5].Width = 100;
                dgvFlights.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvFlights.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;

                dgvReturns.Columns[1].Width = 60;
                dgvReturns.Columns[2].Width = 100;
                dgvReturns.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvReturns.Columns[3].Width = 200;
                dgvReturns.Columns[4].Width = 200;
                dgvReturns.Columns[5].Width = 100;
                dgvReturns.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvReturns.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private Booking AssembleBookingDetails()
        {
            Booking newBooking = new Booking();
            try
            {
                newBooking.ID = 0; //identity on DB
                newBooking.Name = txtName.Text;
                newBooking.Address1 = txtAddress1.Text;
                newBooking.Phone = txtPhone.Text;
                newBooking.Email = txtEmail.Text;
                newBooking.FlightRef = selectedDepartureRef;
                newBooking.Price = selectedDeparturePrice;
                newBooking.PayRef = "";
                return newBooking;
            }
            catch (Exception e4)
            {
                return newBooking;
            }
        }

        private Payment AssemblePaymentDetails()
        {
            Payment newPayment = new Payment();
            try
            {
                newPayment.ID = 0; //identity on DB
                newPayment.Merchant = "Happy Travels";
                newPayment.Name = txtName.Text;
                newPayment.Card = txtCardNo.Text;
                newPayment.Expiry = txtExpiry.Text;
                newPayment.CVV = txtCVV.Text;
                newPayment.ExternalRef = selectedDepartureRef + " " + selectedReturnRef;
                newPayment.Price = selectedTotalPrice;
                return newPayment;
            }
            catch (Exception e5)
            {
                return newPayment;
            }
        }
    }
}
