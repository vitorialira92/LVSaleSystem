using LVSaleSystem.API.Model.Transactions;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LVSaleSystem.API.DTO.Returns
{
    public class ReturnRegisterDTO
    {
        public int UserId { get; set; }
        public int SellingID { get; set; }
        public int SellingItemID { get; set; }
    }
}
