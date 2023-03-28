using System;
using System.Collections.Generic;
using System.Linq;

namespace VISA
{
    public class Payment
    {
        public int ID { get; set; }
        public string Merchant { get; set; }
        public string ExternalRef { get; set; }
        public string Card { get; set; }
        public string Expiry { get; set; }
        public string CVV { get; set; }
        public decimal Price { get; set; }
        public string Name { get; set; }
    }
}
