using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Text.Json;
using AerLingus.BusinessTier;

namespace AerLingus.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class MakeBookingController : ControllerBase
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
                Booking reqBooking = new Booking();
                reqBooking = JsonConvert.DeserializeObject<Booking>(json);
                return myBusinessClass.CreateBooking(reqBooking);
            }
            catch (Exception e)
            {
                return "";
            }
        }
    }
}
