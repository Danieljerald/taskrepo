using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using webapime.Models;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;

namespace webapime.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private IConfiguration _config;
    public WeatherForecastController(IConfiguration configuration)
    {
        _config = configuration;
    }

    private User AuthenticateUser(User user)
    {
        if(user.Username == "admin" && user.Password =="12345")
        {
           User _user = new User { Username = "Nithish Kumar"};
           return _user;
        }
        return null;
    }
    private string GenerateToken(User user)
    {
        var securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
        var credentials = new SigningCredentials(securitykey, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken( _config["jwt:Issuer"],_config["Jwt:Audiece"],null,expires:DateTime.Now.AddMinutes(1),signingCredentials:credentials);
        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    [AllowAnonymous]
    [HttpPost]
    public IActionResult Login (User user)
    {
        IActionResult response = Unauthorized();
        var user_ = AuthenticateUser(user);
        if(user_ != null){
            var token = GenerateToken(user_);
            response = Ok(new { token = token });
        }

        return response;
    }
}


    

