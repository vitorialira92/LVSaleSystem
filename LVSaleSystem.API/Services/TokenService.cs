using LVSaleSystem.API.AccessTokens;
using LVSaleSystem.API.Data;
using LVSaleSystem.API.Model.Users;
using LVSaleSystem.API.Repositories;
using SQLitePCL;
using System.ComponentModel.DataAnnotations;

namespace LVSaleSystem.API.Services
{
    public class TokenService
    {
        private readonly TokenRepository _repository;

        public TokenService(TokenRepository repository)
        {
            _repository = repository;
        }

        internal Token GetToken(string value)
        {
            return _repository.GetByValue(value);
        }

        public string GenerateToken(int userId, UserRole role)
        {
            Token token = new Token
            {
                Value = Guid.NewGuid().ToString(),
                CreatedAt = DateTime.UtcNow,
                ExpiresAt = DateTime.UtcNow.AddHours(2),
                Role = role,
                UserId = userId
            };

            _repository.Add(token);

            return token.Value;
        }
    }
}
