using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VISA.DataTier;

namespace VISA.BusinessTier
{
    public class BusinessClass
    {
        public DataClass myDataClass { get; set; }

        public BusinessClass()
        {
            myDataClass = new DataClass();
        }

        public string CreatePayment(Payment newPayment)
        {
            return myDataClass.CreatePayment(newPayment);
        }
    }
}