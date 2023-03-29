﻿using Microsoft.AspNetCore.Http;
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
    public class ConfirmationController : ControllerBase
    {
        public BusinessClass myBusinessClass { get; set; }

        // POST Confirmation/Post
        [HttpPost]
        public void Post([FromBody] JsonElement body)
        {
            try
            {
                myBusinessClass = new BusinessClass();
                string json = System.Text.Json.JsonSerializer.Serialize(body);
                Confirmation confirmBooking = new Confirmation();
                confirmBooking = JsonConvert.DeserializeObject<Confirmation>(json);
                myBusinessClass.UpdateBooking(confirmBooking);
            }
            catch (Exception e)
            { }
        }
    }
}