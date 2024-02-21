using LVSaleSystem.API.Model.Users;
using System.ComponentModel.DataAnnotations;

namespace LVSaleSystem.API.AccessTokens
{
    public class Token
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Value { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        [Required]
        public DateTime ExpiresAt { get; set; }
        [Required]
        public UserRole Role { get; set; }
        [Required]
        public int UserId { get; set; }
    }
}
