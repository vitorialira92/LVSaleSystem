using LVSaleSystem.API.Model.Transactions;
using LVSaleSystem.API.Model.Users.Customers;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LVSaleSystem.API.DTO.Selling
{
    public class SellingRegisterDTO
    {
        [Required]
        public List<SellingItemRegisterDTO> Items { get; set; }
        [Required]
        
        public int CustomerId { get; set; }
    }
}
