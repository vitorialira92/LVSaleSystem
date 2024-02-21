using LVSaleSystem.API.DTO;
using LVSaleSystem.API.DTO.Product;
using LVSaleSystem.API.Filters;
using LVSaleSystem.API.Model.Products;
using LVSaleSystem.API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

namespace LVSaleSystem.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClothingController : ControllerBase
    {
        private readonly ProductService _service;
        private readonly IContentTypeProvider _contentTypeProvider;

        public ClothingController(ProductService service, IContentTypeProvider contentTypeProvider)
        {
            _service = service;
            _contentTypeProvider = contentTypeProvider;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_service.GetAll());
        }
        
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_service.GetById(id));
        }

        [HttpPost]
        [AdminAuthorizationFilter]
        public IActionResult AddClothing([FromBody] ClothingRegisterDTO clothingDTO)
        {
            return Ok(_service.AddClothing(clothingDTO));
        }
        
        [HttpPost("/picture/{id}")]
        [AdminAuthorizationFilter]
        public async Task<IActionResult> AddClothingPicure(IFormFile picture, [FromRoute] int id)
        {
            if (ValidateFile(picture) != null)
            {
                return ValidateFile(picture);
            }

            return Ok(await _service.AddClothingPicture(id, picture));
        }

        private IActionResult? ValidateFile(IFormFile file)
        {
            if (file.Length > 20 * 1024 * 1024)
            {
                throw new BadHttpRequestException("Arquivo maior que o permitido");
            }

            string[] possibleExtensions = [".png", ".jpg"];

            var extensao = Path.GetExtension(file.FileName);

            if (!possibleExtensions.Contains(extensao))
            {
                throw new BadHttpRequestException("Arquivo deve ser png ou jpg");
            }

            return null;
        }
    }
}
