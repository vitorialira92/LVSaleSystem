using Microsoft.AspNetCore.Mvc;
using LVSaleSystem.API.Filters;

namespace LVSaleSystem.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [AdminAuthorizationFilter]
    public class ManagerController
    {
    }
}
