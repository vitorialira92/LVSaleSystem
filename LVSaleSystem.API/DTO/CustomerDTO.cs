using LVSaleSystem.API.Attributes;
using LVSaleSystem.API.Model.Users.Customers;
using LVSaleSystem.API.Model.Users;
using System.ComponentModel.DataAnnotations;

namespace LVSaleSystem.API.DTO
{
    public class CustomerDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public UserRole Role { get; set; }
        [Required]
        [CPF(ErrorMessage = "CPF inválido")]
        public string CPF { get; set; }
        [Required]
        public WalletDTO Wallet { get; set; }

        public CustomerDTO() { }

        public CustomerDTO(Customer customer)
        {
            this.Id = customer.Id;
            this.Name = customer.Name;
            this.Email = customer.Email;
            this.CPF = customer.CPF;
            this.Username = customer.UserDetails.UserName;
            this.Role = customer.UserDetails.Role;
            CreditCardDTO creditCard = null;
            if (customer.Wallet.CreditCard != null)
                creditCard = new CreditCardDTO
                {
                    Id = customer.Wallet.CreditCard.Id,
                    Number = customer.Wallet.CreditCard.Number,
                    ExpirationDate = customer.Wallet.CreditCard.ExpirationDate
                };


            this.Wallet = new WalletDTO
            {
                Id = customer.Wallet.Id,
                Balance = customer.Wallet.Balance,
                CreditCard = creditCard
            };
            
        }
    }
}
