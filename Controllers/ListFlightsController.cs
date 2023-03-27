using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using AerLingus.BusinessTier;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AerLingus.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ListFlightsController : ControllerBase
    {
        public BusinessClass myBusinessClass { get; set; }
        
        // GET: ListFlights/Get
        [HttpGet]
        public List<Flight> Get()
        {
            myBusinessClass = new BusinessClass();
            List<Flight> availableFlights = myBusinessClass.GetFlights();
            return availableFlights;
        }

        // GET ListFlights/Get/Date
        [HttpGet("{dt}")]
        public List<Flight> Get(string dt)
        {
            myBusinessClass = new BusinessClass();
            List<Flight> availableFlights = myBusinessClass.GetFlights(dt);
            return availableFlights;
        }
    }
}
