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

namespace TravelAgent
{
    public partial class MakeBooking : Form
    {
        public MakeBooking()
        {
            InitializeComponent();
        }

        private async void btnSearchFlights_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";

            using var aerlingusClient = new HttpClient();
            aerlingusClient.BaseAddress = new Uri("https://localhost:44387");
            HttpResponseMessage result1 = await aerlingusClient.GetAsync("ListFlights/Get");
            string content1 = await result1.Content.ReadAsStringAsync();
            textBox1.Text = content1;

            using var ryanairClient = new HttpClient();
            ryanairClient.BaseAddress = new Uri("https://localhost:44354");
            HttpResponseMessage result2 = await ryanairClient.GetAsync("ListFlights/Get");
            string content2 = await result2.Content.ReadAsStringAsync();
            textBox1.Text = textBox1.Text + " - " + content2;
        }
    }
}
