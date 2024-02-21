using Microsoft.AspNetCore.Mvc;
using LVSaleSystem.API.Filters;
using LVSaleSystem.API.Services;
using LVSaleSystem.API.DTO;

namespace LVSaleSystem.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    
    public class ManagerController
    {
        private readonly ManagerService _service;
        public ManagerController(ManagerService service)
        {
            _service = service;
        }
        [HttpPost]
        public ManagerDTO AddManager([FromBody] ManagerRegisterDTO managerDTO)
        {
            return _service.AddManager(managerDTO);
        }
    }
}
