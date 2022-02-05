using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelBooking.Models;

namespace TravelBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        //1 dpendency injection for configuration

        private readonly IConfiguration _config;

        //2 Constructor injection

        public LoginController(IConfiguration config)
        {
            _config = config;
        }
        //3 http post
        [HttpPost("token")]

        public IActionResult Login([FromBody] UserModel user)
        {
            //checking unauthorised
            IActionResult response = Unauthorized();

            //authenticate the user

            var loginUser = AuthenticateUser(user);

            //validate the user and generate jwt token
            if (loginUser != null)
            {
                var tokenString = GenerateJWToken(loginUser);
                response = Ok(new { token = tokenString });
            }
            return response;
            //return Ok("Hello from API");
        }



        // 4 authenticte user

        private object AuthenticateUser(UserModel user)
        {
            UserModel loginUser = null;

            //validate the user credentials

           

            if (user.UserName == "admin")
            {
                loginUser = new UserModel
                {
                    UserName = "admin",
                    EmailAddress = "admin@gmail.com",
                    Role = "Administartor"
                };
            }
            return loginUser;

        }

        //5 generate JWt token

        private object GenerateJWToken(object loginUser)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));

            //signing credential
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            //claims--roles

            //generate token
            var token = new JwtSecurityToken(
                _config["Jwt:Issuer"], //header
                _config["Jwt:Issuer"],  //payload
                expires: DateTime.Now.AddMinutes(2),
                signingCredentials: credentials
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
