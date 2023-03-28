using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Text.Json;
using Ryanair.BusinessTier;

namespace Ryanair.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ConfirmationController : ControllerBase
    {
        public BusinessClass myBusinessClass { get; set; }

        // POST Confirmation/Post
        [HttpPost]
        public void Post([FromBody] JsonElement body)
        {
            myBusinessClass = new BusinessClass();
            string json = System.Text.Json.JsonSerializer.Serialize(body);
            Confirmation confirmBooking = new Confirmation();
            confirmBooking = JsonConvert.DeserializeObject<Confirmation>(json);
            myBusinessClass.UpdateBooking(confirmBooking);
        }
    }
}
