using LVSaleSystem.API.Model.Users.Customers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LVSaleSystem.API.Model.Transactions
{
    public class Selling
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public virtual List<SellingItem> Items { get; set; }
        [NotMapped]
        public decimal Total { get {
                decimal total = 0;

                foreach (var item in Items)
                    total += item.Total;

                return total;
            } }
        [Required]
        public virtual Payment Payment { get; set; }
        [Required]
        public virtual Customer Customer { get; set; }
    }
}
