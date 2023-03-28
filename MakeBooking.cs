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
            paymentClient.BaseAddress = new Uri("https://localhost:44386");  //needs to change once VISA project built....
        }

        private async void btnSearchFlights_Click(object sender, EventArgs e)
        {
            // myBusinessClass = new BusinessClass();

            //to format Departure date & Arrival date in date-only format: '01-Apr-2023'
            string depDate = dtDeparture.Value.ToString("dd-MMM-yyyy");
            string retDate = dtReturn.Value.ToString("dd-MMM-yyyy");

            ///// Aer Lingus /////

            //Aer Lingus Web API
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

            ///// Aer Lingus /////

            // ---------------- //

            /////  Ryanair   /////

            //Ryanair Web API

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

            /////  Ryanair   /////

            //sort list by departure date and bind to grid
            List<Flight> sortedFlights = availableFlights.OrderBy(x => x.Departure).ToList();
            dgvFlights.DataSource = sortedFlights;

            //sort list by return date and bind to grid
            List<Flight> sortedReturnFlights = returnFlights.OrderBy(x => x.Departure).ToList();
            dgvReturns.DataSource = sortedReturnFlights;

            //cosmetics
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

        private void btnSelectFlights_Click(object sender, EventArgs e)
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

        private async void btnPay_Click(object sender, EventArgs e)
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
            Booking outwardBooking = new Booking();
            outwardBooking.ID = 0; //identity on DB
            outwardBooking.Name = txtName.Text;
            outwardBooking.Address1 = txtAddress1.Text;
            outwardBooking.Phone = txtPhone.Text;
            outwardBooking.Email = txtEmail.Text;
            outwardBooking.FlightRef = selectedDepartureRef;
            outwardBooking.Price = selectedDeparturePrice;
            outwardBooking.PayRef = "";

            //Assemble return booking details
            Booking returnBooking = new Booking();
            returnBooking.ID = 0; //identity on DB
            returnBooking.Name = txtName.Text;
            returnBooking.Address1 = txtAddress1.Text;
            returnBooking.Phone = txtPhone.Text;
            returnBooking.Email = txtEmail.Text;
            returnBooking.FlightRef = selectedReturnRef;
            returnBooking.Price = selectedReturnPrice;
            returnBooking.PayRef = "";

            //Assemble payment details
            Payment currentPayment = new Payment();
            currentPayment.ID = 0; //identity on DB
            currentPayment.Merchant = "Happy Travels";
            currentPayment.Name = txtName.Text;
            currentPayment.Card = txtCardNo.Text;
            currentPayment.Expiry = txtExpiry.Text;
            currentPayment.CVV = txtCVV.Text;
            currentPayment.ExternalRef = selectedDepartureRef + " " + selectedReturnRef;
            currentPayment.Price = selectedTotalPrice;

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
            //handling response/errors?

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
            //handling response/errors?

            ////////////////////////////////////////////////////////////
            //Step 2: Create Payment record on VISA - if transaction fails then Carrier Booking will expire. If transaction succeeds then Payment Ref can be passed back to Carrier to commit transaction
            ////////////////////////////////////////////////////////////

            //Post Payment
            byteContent = new ByteArrayContent(System.Text.Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(currentPayment)));
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            paymentResponse = await paymentClient.PostAsync("MakePayment/Post/", byteContent);
            paymentRef = await paymentResponse.Content.ReadAsStringAsync(); //paymentRef will contain newly created ID on Payment Record
            //handling response/errors?

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
                        bookingResponse = await aerLingusClient.PostAsync("MakeBooking/Post/", byteContent);
                        break;
                    default:
                        bookingResponse = await ryanairClient.PostAsync("MakeBooking/Post/", byteContent);
                        break;
                }

                bookingResult = await bookingResponse.Content.ReadAsStringAsync();
                //handling response/errors?

                //Update Return Booking with Payment Ref
                Confirmation returnConfirmation = new Confirmation();
                Int32.TryParse(returnBookingRef, out returnRef);
                returnConfirmation.BookingID = outwardRef;
                returnConfirmation.PayRef = "Ref: " + paymentRef;
                byteContent = new ByteArrayContent(System.Text.Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(returnConfirmation)));
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

                bookingResult = await bookingResponse.Content.ReadAsStringAsync();
                //handling response/errors?
            }
        }
    }
}
