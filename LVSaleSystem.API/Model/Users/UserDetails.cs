
namespace LVSaleSystem.API.Model.Users
{
    using LVSaleSystem.API.Util;
    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations;
    using System.Security.Cryptography;

    public class UserDetails
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string HashedPassword { get;  set; }
        [Required]
        public string Salt { get;  set; }
        [Required]
        public UserRole Role { get; set; }
        public UserDetails() { }
        public UserDetails(string username, string password, UserRole role)
        {
            this.UserName = username;
            this.Role = role;
            SetPassword(password);
        }
        public UserDetails(string usename, string hashedPassword, string salt, UserRole role)
        {
            this.Salt = salt;
            this.UserName = usename;
            this.Role = role;
            this.HashedPassword = hashedPassword;
        }
        private void SetPassword(string password)
        {
            (this.HashedPassword, this.Salt) = HashUtil.GetHashedAndSalt(password);
        }
    }
}
