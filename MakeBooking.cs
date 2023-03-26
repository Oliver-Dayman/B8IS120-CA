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
        public MakeBooking()
        {
            InitializeComponent();
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
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
