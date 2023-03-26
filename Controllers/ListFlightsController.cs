using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            myBusinessClass = new BusinessClass();
            List<Flight> availableFlights = myBusinessClass.GetFlights();
            return availableFlights;
        }

        // GET ListFlights/Get/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST ListFlights/Post
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT ListFlights/Put/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }
    }
}
