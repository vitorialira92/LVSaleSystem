using LVSaleSystem.API.DTO.Selling;
using LVSaleSystem.API.Model.Transactions;
using LVSaleSystem.API.Repositories;
using LVSaleSystem.API.Services;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace LVSaleSystem.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SellingController : ControllerBase
    {
        private readonly SellingService _service;
        private readonly ILogger<SellingController> _logger;
        public SellingController(SellingService service, ILogger<SellingController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            var selling = _service.GetById(id);
            return Ok(selling);
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var selling = _service.GetAll();
            return Ok(selling);
        }

        [HttpPost]
        public IActionResult Post([FromBody] SellingRegisterDTO sellingDTO)
        {
            var result = _service.Add(sellingDTO);
            return Ok(result);
        }

    }
}
