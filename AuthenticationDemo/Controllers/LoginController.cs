using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AuthenticationDemo.Controllers
{
    [ApiController]
    [Route("api/authentication")]
    public class LoginController : ControllerBase
    {
        /// <summary>
        /// Login endpoint
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        ///
        [AllowAnonymous]
        [HttpPost, Route("login")]
        public IActionResult Login([FromBody] Login login)
        {
            try
            {
                if (string.IsNullOrEmpty(login.UserName) || string.IsNullOrEmpty(login.Password))
                {
                    return BadRequest("Username and/or Password not specified");
                }

                if (login.UserName.Equals("fpug") && login.Password.Equals("fpug"))
                {
                    var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("thisisasecretkey@123"));

                    var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                    var jwtSecurityToken = new JwtSecurityToken(
                        issuer: "ABCXYZ",
                        audience: "http://localhost:51398",
                        // claims: new List<Claim>(),
                        expires: DateTime.Now.AddMinutes(10),
                        signingCredentials: signinCredentials
                    );

                    return Ok(new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken));
                }
            }
            catch
            {
                return BadRequest("An error occurred in generating the token");
            }

            return Unauthorized();
        }
    }
}

