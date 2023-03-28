using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace VISA.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        // GET: Home/Get
        [HttpGet]
        public string Get()
        {
            return "Home Page";
        }
    }
}
