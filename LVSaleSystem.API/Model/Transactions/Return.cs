using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LVSaleSystem.API.Model.Transactions
{
    public class Return
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public virtual Selling Selling { get; set; }
        [Required]
        public virtual SellingItem SellingItem { get; set; }
        [NotMapped]
        public decimal Value { get { return SellingItem.Total; } }
    }
}
