using LVSaleSystem.API.DTO;
using LVSaleSystem.API.DTO.Product;
using LVSaleSystem.API.Model.Products;
using LVSaleSystem.API.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using LVSaleSystem.API.Exceptions;

namespace LVSaleSystem.API.Services
{
    public class ProductService
    {
        public ProductsRepository _repository;

        public ProductService(ProductsRepository repository)
        {
            _repository = repository;
        }

        internal Clothing AddClothing(ClothingRegisterDTO clothingDTO)
        {
            var fileName = new Guid().ToString();
            Clothing clothing = new Clothing
            {
                Name = clothingDTO.Name,
                Description = clothingDTO.Description,
                Price = clothingDTO.Price,
                Type = (ClothingType)clothingDTO.Type
            };
            int quantity = clothingDTO.Quantity;
            return _repository.Add(clothing, quantity);
        }

        internal async Task<string> AddClothingPicture(int id, IFormFile picture)
        {
            var clothing = _repository.GetById(id);

            if (clothing == null)
                throw new ResourceNotFoundException("Peça de roupa", 400);


            var fileName = Guid.NewGuid().ToString();
            var extensao = Path.GetExtension(picture.FileName);

            clothing.PictureFileName = fileName + extensao;

            var path = $"wwwroot/{fileName}{extensao}";

            using (var fileStream = System.IO.File.Create(path))
            {
                await picture.CopyToAsync(fileStream);
            }

            _repository.AddClothingPicture(clothing);

            return fileName;
        }

        internal List<Clothing> GetAll()
        {
            return _repository.GetAll();
        }

        internal Clothing GetById(int id)
        {
            return _repository.GetById(id);
        }
    }
}
