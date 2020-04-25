using System.Threading.Tasks;
using AutoMapper;
using EDzController.Controllers.V1.Resources;
using EDzController.Domain.Models;
using EDzController.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace EDzController.Controllers.V1.User
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class UsersController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public UsersController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserAsync([FromBody] UserCredentialsResource userCredentials)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = _mapper.Map<UserCredentialsResource, Domain.Models.User>(userCredentials);

            var response = await _userService.CreateUserAsync(user, ERole.Student);
            if (!response.Success)
            {
                return BadRequest(response.Message);
            }

            var userResource = _mapper.Map<Domain.Models.User, UserResource>(response.User);
            return Ok(userResource);
        }

    }
}