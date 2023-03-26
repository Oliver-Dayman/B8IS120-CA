using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ryanair.DataTier;

namespace Ryanair.BusinessTier
{
    public class BusinessClass
    {
        public DataClass myDataClass { get; set; }

        public BusinessClass()
        {
            myDataClass = new DataClass();
        }

        public List<Flight> GetFlights()
        {
            return myDataClass.GetFlights();
        }

        public List<Flight> GetFlights(DateTime dt)
        {
            return myDataClass.GetFlights(dt);
        }
    }
}
