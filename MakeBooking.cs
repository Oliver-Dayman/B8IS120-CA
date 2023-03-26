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


            ///// Aer Lingus /////

            //Aer Lingus Web API
            HttpClient aerlingusClient = new HttpClient();
            aerlingusClient.BaseAddress = new Uri("https://localhost:44387");
            HttpResponseMessage aerLingusResult;
            string aerLingusContent;

            //Retrieve Aer Lingus flights
            if (dtDeparture.Value == null)
            {
                aerLingusResult = await aerlingusClient.GetAsync("ListFlights/Get");
            }
            else
            {
                aerLingusResult = await aerlingusClient.GetAsync("ListFlights/Get/" + dtDeparture.Value);
            }
            aerLingusContent = await aerLingusResult.Content.ReadAsStringAsync();
            
            //Add to empty list for display in grid
            List<Flight> availableFlights = JsonConvert.DeserializeObject<List<Flight>>(aerLingusContent);

            ///// Aer Lingus /////
            
            // ---------------- //

            /////  Ryanair   /////

            //Ryanair Web API
            HttpClient ryanairClient = new HttpClient();
            ryanairClient.BaseAddress = new Uri("https://localhost:44354");
            HttpResponseMessage ryanairResult;
            string ryanairContent;

            //Retrieve Ryanair flights
            if (dtDeparture.Value == null)
            {
                ryanairResult = await ryanairClient.GetAsync("ListFlights/Get");
            }
            else
            {
                ryanairResult = await ryanairClient.GetAsync("ListFlights/Get/" + dtDeparture.Value);
            }
            ryanairContent = await ryanairResult.Content.ReadAsStringAsync();

            //add Ryanair flights to existing list (single list for both airlines)
            availableFlights.AddRange(JsonConvert.DeserializeObject<List<Flight>>(ryanairContent));

            /////  Ryanair   /////

            //sort list by departure date and bind to grid
            List<Flight> sortedFlights = availableFlights.OrderBy(x => x.Departure).ToList();
            dgvFlights.DataSource = sortedFlights;
        }
    }
}
