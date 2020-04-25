using System.Linq;
using EDzController.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EDzController.Controllers.V1
{
    [ApiController]
    public class ProtectedController : Controller
    {
        private readonly IUserService _userService;

        public ProtectedController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Authorize(Roles = "Teacher")]
        [Route("/api/v1/teacher")]
        public IActionResult GetProtectedData()
        {
            return Ok("Teacher info");
        }

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        [Route("/api/v1/admin")]
        public IQueryable<object> GetAllUsers()
        {
            return _userService.GetAllUsers();
        }
    }
}