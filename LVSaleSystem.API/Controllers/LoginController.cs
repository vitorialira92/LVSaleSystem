using LVSaleSystem.API.DTO.Login;
using LVSaleSystem.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace LVSaleSystem.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly LoginService _service;
        public LoginController(LoginService service)
        {
            _service = service;
        }
        [HttpPost]
        public IActionResult Login([FromBody] LoginRequest loginRequest)
        {
            return Ok(_service.Login(loginRequest));
        }
    }
}
