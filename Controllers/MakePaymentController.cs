using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Text.Json;
using VISA.BusinessTier;

namespace VISA.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class MakePaymentController : ControllerBase
    {
        public BusinessClass myBusinessClass { get; set; }

        // POST MakeBooking/Post
        [HttpPost]
        public string Post([FromBody] JsonElement body)
        {
            try
            {
                myBusinessClass = new BusinessClass();
                string json = System.Text.Json.JsonSerializer.Serialize(body);
                Payment reqPayment = new Payment();
                reqPayment = JsonConvert.DeserializeObject<Payment>(json);
                return myBusinessClass.CreatePayment(reqPayment);
            }
            catch (Exception e)
            {
                return "";
            }
        }
    }
}
