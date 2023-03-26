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
        string selectedCarrier = "";
        int selectedDepartureId = 0;
        int selectedReturnId = 0;
        decimal selectedTotalPrice = 0;
        public MakeBooking()
        {
            InitializeComponent();
            pnlBookingHeader.Visible = false;
            pnlBookingDetails.Visible = false;
        }

        private async void btnSearchFlights_Click(object sender, EventArgs e)
        {
            // myBusinessClass = new BusinessClass();

            //to format Departure date & Arrival date in date-only format: '01-Apr-2023'
            string depDate = dtDeparture.Value.ToString("dd-MMM-yyyy");
            string retDate = dtReturn.Value.ToString("dd-MMM-yyyy");

            ///// Aer Lingus /////

            //Aer Lingus Web API
            HttpClient aerlingusClient = new HttpClient();
            aerlingusClient.BaseAddress = new Uri("https://localhost:44387");
            HttpResponseMessage aerLingusResult;
            string aerLingusContent;

            //Retrieve Aer Lingus flights for departure
            aerLingusResult = await aerlingusClient.GetAsync("ListFlights/Get/" + depDate);
            aerLingusContent = await aerLingusResult.Content.ReadAsStringAsync();
            
            //Add to empty list for display in grid
            List<Flight> availableFlights = JsonConvert.DeserializeObject<List<Flight>>(aerLingusContent);

            //Retrieve Aer Lingus flights for return
            aerLingusResult = await aerlingusClient.GetAsync("ListFlights/Get/" + retDate);
            aerLingusContent = await aerLingusResult.Content.ReadAsStringAsync();

            //Add to empty list for display in grid
            List<Flight> returnFlights = JsonConvert.DeserializeObject<List<Flight>>(aerLingusContent);

            ///// Aer Lingus /////

            // ---------------- //

            /////  Ryanair   /////

            //Ryanair Web API
            HttpClient ryanairClient = new HttpClient();
            ryanairClient.BaseAddress = new Uri("https://localhost:44354");
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
                    selectedDepartureId = (int)dgvFlights.SelectedRows[0].Cells[1].Value;
                    selectedReturnId = (int)dgvReturns.SelectedRows[0].Cells[1].Value;
                    selectedTotalPrice = (decimal)dgvFlights.SelectedRows[0].Cells[5].Value + (decimal)dgvReturns.SelectedRows[0].Cells[5].Value;
                    txtPrice.Text = selectedTotalPrice.ToString("F2");
                    pnlBookingHeader.Visible = true;
                    pnlBookingDetails.Visible = true;
                }
            }
        }

        private void btnPay_Click(object sender, EventArgs e)
        {





            //Aer Lingus Web API
            HttpClient aerlingusClient = new HttpClient();
            aerlingusClient.BaseAddress = new Uri("https://localhost:44387");
            HttpResponseMessage aerLingusResult;
            string aerLingusContent;

            //Retrieve Aer Lingus flights for departure
            aerLingusResult = await aerlingusClient.GetAsync("ListFlights/Get/" + depDate);
            aerLingusContent = await aerLingusResult.Content.ReadAsStringAsync();

            //Add to empty list for display in grid
            List<Flight> availableFlights = JsonConvert.DeserializeObject<List<Flight>>(aerLingusContent);

            //Retrieve Aer Lingus flights for return
            aerLingusResult = await aerlingusClient.GetAsync("ListFlights/Get/" + retDate);
            aerLingusContent = await aerLingusResult.Content.ReadAsStringAsync();

            //Add to empty list for display in grid
            List<Flight> returnFlights = JsonConvert.DeserializeObject<List<Flight>>(aerLingusContent);
        }
    }
}
