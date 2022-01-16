using System.Threading.Tasks;
using AutoMapper;
using EDzController.Controllers.V1.Resources;
using EDzController.Domain.Security.Tokens;
using EDzController.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace EDzController.Controllers.V1.User
{
    [ApiController]
    public class LoginController : Controller
    {
        private readonly ILoginService _loginService;
        private readonly IMapper _mapper;

        public LoginController(IMapper mapper, ILoginService loginService)
        {
            _loginService = loginService;
            _mapper = mapper;
        }

        [Route("/api/v1/login")]
        [HttpPost]
        public async Task<IActionResult> LoginAsync([FromBody] UserCredentialsResource userCredentials)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var response = await _loginService.CreateAccessTokenAsync(userCredentials.Email, userCredentials.Password);
            if (!response.Success) return BadRequest(response.Message);

            var accessTokenResource = _mapper.Map<AccessToken, AccessTokenResource>(response.Token);
            return Ok(accessTokenResource);
        }

        [Route("/api/v1/token/refresh")]
        [HttpPost]
        public async Task<IActionResult> RefreshTokenAsync([FromBody] RefreshTokenResource refreshTokenResource)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var response = await _loginService.RefreshTokenAsync(refreshTokenResource.Token, refreshTokenResource.UserEmail);
            if (!response.Success) return BadRequest(response.Message);

            var tokenResource = _mapper.Map<AccessToken, AccessTokenResource>(response.Token);
            return Ok(tokenResource);
        }

        [Route("/api/v1/token/revoke")]
        [HttpPost]
        public IActionResult RevokeToken([FromBody] RevokeTokenResource revokeTokenResource)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            _loginService.RevokeRefreshToken(revokeTokenResource.Token);
            return NoContent();
        }
    }
}