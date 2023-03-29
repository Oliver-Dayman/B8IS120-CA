using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Ryanair.BusinessTier;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ryanair.Controllers
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
            List<Flight> availableFlights = new List<Flight>();
            try
            {
                myBusinessClass = new BusinessClass();
                availableFlights = myBusinessClass.GetFlights();
                return availableFlights;
            }
            catch (Exception e)
            {
                return availableFlights;
            }
        }

        // GET ListFlights/Get/Date
        [HttpGet("{dt}")]
        public List<Flight> Get(string dt)
        {
            List<Flight> availableFlights = new List<Flight>();
            try
            {
                myBusinessClass = new BusinessClass();
                availableFlights = myBusinessClass.GetFlights(dt);
                return availableFlights;
            }
            catch (Exception e)
            {
                return availableFlights;
            }
        }
    }
}
