using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AerLingus
{
    public class Booking
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address1 { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string FlightRef { get; set; }
        public decimal Price { get; set; }
        public string PayRef { get; set; }
    }
}
