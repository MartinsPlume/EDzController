using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EDzController.Controllers.V1
{
    [ApiController]
    public class ProtectedController : Controller
    {
        [HttpGet]
        [Authorize]
        [Route("/api/v1/teacher")]
        public IActionResult GetProtectedData()
        {
            return Ok("Teacher info");
        }

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        [Route("/api/v1/admin")]
        public IActionResult GetProtectedDataForAdmin()
        {
            return Ok("Administrator information");
        }
    }
}
