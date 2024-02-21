using LVSaleSystem.API.DTO.Returns;
using LVSaleSystem.API.DTO.Selling;
using LVSaleSystem.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace LVSaleSystem.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReturnsController : ControllerBase
    {
        private readonly ReturnsService _service;
        private readonly ILogger<ReturnsController> _logger;
        public ReturnsController(ReturnsService service, ILogger<ReturnsController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var selling = _service.GetAll();
            return Ok(selling);
        }
        [HttpPost]
        public IActionResult Post([FromBody] ReturnRegisterDTO returnDTO)
        {
            var result = _service.Add(returnDTO);
            return Ok(result);
        }
    }
}
