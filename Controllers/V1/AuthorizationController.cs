using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace EDzController.Controllers.V1
{
    [Route("api/v1/[controller]")]
    public class AuthorizationController : Controller
    {
        [HttpPost("token")]
        public IActionResult Token()
        {
            var claimsData = new [] {new Claim(ClaimTypes.Name, "userName")};
            var tokenString = new JwtSecurityToken(
                issuer: "EDzEducation",
                audience: "EDzEducation",
                claims: claimsData);
            
            return Ok(tokenString);
        }
        
    }
}