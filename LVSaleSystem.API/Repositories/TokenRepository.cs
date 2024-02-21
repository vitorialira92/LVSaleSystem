using LVSaleSystem.API.AccessTokens;
using LVSaleSystem.API.Data;

namespace LVSaleSystem.API.Repositories
{
    public class TokenRepository : IRepository<Token>
    {
        private readonly LVContext _context;

        public TokenRepository(LVContext context)
        {
            _context = context;
        }

        public Token Add(Token entity)
        {
            _context.Tokens.Add(entity);
            _context.SaveChanges();

            return entity;
        }

        public void Delete(Token entity)
        {
            _context.Tokens.Remove(entity);
            _context.SaveChanges();
        }

        public Token GetById(int id)
        {
            var token = _context.Tokens.FirstOrDefault(x => x.Id == id);
            if (token?.ExpiresAt > DateTime.UtcNow)
            {
                Delete(token);
                return null;
            }
            return token;
        }
        
        public Token GetByValue(string value)
        {
            var token = _context.Tokens.FirstOrDefault(x => x.Value == value);
            if (token?.ExpiresAt < DateTime.UtcNow)
            {
                Delete(token);
                return null;
            }
            return token;
        }

    }
}
