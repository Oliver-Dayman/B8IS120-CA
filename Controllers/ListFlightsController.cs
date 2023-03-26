using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AerLingus.BusinessTier;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AerLingus.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ListFlightsController : ControllerBase
    {
        public BusinessClass myBusinessClass { get; set; }
        
        // GET: api/<ListFlightsController>
        [HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}
        public string Get()
        {
            myBusinessClass = new BusinessClass();
            List<Flight> availableFlights = myBusinessClass.GetFlights();
            return availableFlights.Count.ToString();
        }

        // GET api/<ListFlightsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ListFlightsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ListFlightsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ListFlightsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
