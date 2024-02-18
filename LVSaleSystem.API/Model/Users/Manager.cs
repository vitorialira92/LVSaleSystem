using System.ComponentModel.DataAnnotations;

namespace LVSaleSystem.API.Model.Users
{
    public class Manager
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public UserDetails UserDetails { get; set; }
    }
}
