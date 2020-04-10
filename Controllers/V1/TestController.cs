using System;
using System.Collections.Generic;
using EDzController.Contracts.V1;
using EDzController.Controllers.V1.Requests;
using EDzController.Controllers.V1.Responses;
using EDzController.Domain;
using Microsoft.AspNetCore.Mvc;

namespace EDzController.Controllers.V1
{
    public class TestController : Controller
    {
        private List<Test> _tests;

        public TestController()
        {
            _tests = new List<Test>();
            for (var i = 0; i < 5; i++)
            {
                _tests.Add(new Test{Id = Guid.NewGuid().ToString()});
            }
        }

        [HttpGet(ApiRoutes.Tests.GetAll)]
        public IActionResult GetAll()
        {
            return Ok(_tests);
        }
    }
}