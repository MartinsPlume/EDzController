using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EDzController.Controllers
{
    public class DummyController : Controller
    {
        [HttpGet("api/dummy")]
        public IActionResult Index()
        {
            return Ok(new {name = "Martin"});
        }
    }
}