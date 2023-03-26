using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AerLingus
{
    public class Flight
    {
        public string Carrier { get; set; }
        public int ID { get; set; }
        public string Reference { get; set; }
        public DateTime Departure { get; set; }
        public DateTime Arrival { get; set; }
        public decimal Price { get; set; }
    }
}
