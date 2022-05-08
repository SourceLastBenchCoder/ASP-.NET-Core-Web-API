using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using My.Simple.Web.API.Interfaces;

namespace My.Simple.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IJWTManager _jwtAuth;
        public LoginController(IJWTManager jwtAuth)
        {
            _jwtAuth = jwtAuth;
        }

        [HttpPost]
        [Route("token")]
        [AllowAnonymous]
        public IActionResult Authenticate(string userId, string password)
        {

            var token = _jwtAuth.Authenticate(userId, password);

            return Ok(token);
        }
    }
}
