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
            textBox1.Text = "";

            //Retrieve Aer Lingus flights
            HttpClient aerlingusClient = new HttpClient();
            aerlingusClient.BaseAddress = new Uri("https://localhost:44387");
            HttpResponseMessage aerLingusResult = await aerlingusClient.GetAsync("ListFlights/Get");
            string aerLingusContent = await aerLingusResult.Content.ReadAsStringAsync();

            List<Flight> availableFlights = JsonConvert.DeserializeObject<List<Flight>>(aerLingusContent);

            //Retrieve Ryanair flights
            //HttpClient ryanairClient = new HttpClient();
            //ryanairClient.BaseAddress = new Uri("https://localhost:44354");
            //HttpResponseMessage ryanairResult = await ryanairClient.GetAsync("ListFlights/Get");
            //string ryanairContent = await ryanairResult.Content.ReadAsStringAsync();
            //List<Flight> availableFlights = JsonConvert.DeserializeObject<List<Flight>>(aerLingusContent); (need to add to existing list)

            textBox1.Text = availableFlights.ToString();   //need to change to grid
        }
    }
}
