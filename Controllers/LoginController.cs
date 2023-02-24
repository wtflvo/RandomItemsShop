using Microsoft.AspNetCore.Mvc;
using RandomItemsShop.Models;
using RandomItemsShop.DbConnectors;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

using System.Text;


namespace RandomItemsShop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {



        private readonly ILogger<LoginController> _logger;

        public LoginController(ILogger<LoginController> logger)
        {
            _logger = logger;
        }

        [HttpPost]

        public IActionResult Login([FromBody] LoggedUser user)
        {

            if (user is null)
            {
                return BadRequest("Invalid client request");
            }

            DbReader dbReader = new();

            List<UsersTable> usersInDB = dbReader.checkUserInDB(user);
            
        
            if (usersInDB.Count == 1)
            {
                
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("INeedThisJob@123"));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                var tokenOptions = new JwtSecurityToken(
                    issuer: "http://localhost:5262",
                    audience: "http://localhost:5262",
                    expires: DateTime.Now.AddDays(3),
                    signingCredentials: signinCredentials
                    
                );
                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
                return Ok(new AuthenticatedResponse { Token = tokenString });
            }
            return Unauthorized();
        }


    }
}