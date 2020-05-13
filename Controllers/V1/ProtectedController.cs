using System.Collections.Generic;
using System.Linq;
using EDzController.Domain.Models;
using EDzController.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EDzController.Controllers.V1
{
    [ApiController]
    public class ProtectedController : Controller
    {
        private readonly IUserService _userService;

        public ProtectedController(IUserService userService) => _userService = userService;
        
        [HttpGet]
        [Authorize(Roles = "Student, Teacher")]
        [Route("/api/v1/test")]
        public string Test()
        {
            var currentUser = HttpContext.User;
            var userRole = currentUser
                .Claims
                .FirstOrDefault(c => c.Type == "UserRole")?
                .Value
                .ToString();
            return userRole;
        }

        [HttpGet]
        [Authorize(Roles = "Teacher")]
        [Route("/api/v1/students")]
        public IEnumerable<UserInfo> GetStudentList()
        {
            return _userService.GetStudents();
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
        public IActionResult GetAdminData()
        {
            return Ok("Administrator info");
        }
    }
}