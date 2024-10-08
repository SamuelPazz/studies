using Microsoft.AspNetCore.Mvc;
using RestApi.Services;

namespace RestApi.Controllers
{
    [ApiController]
    [Route("api/v1/auth")]
    public class AuthController : Controller
    {
        [HttpPost]
        public IActionResult Auth(string username, string password)
        {
            if (username == "Samuel" && password == "123456")
            {
                var token = TokenService.GenerateToken(new Models.Employee());
                return Ok(token);
            }
            return BadRequest("username or password invalid");
        }
    }
}