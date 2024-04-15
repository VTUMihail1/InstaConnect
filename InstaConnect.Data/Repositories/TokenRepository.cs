using InstaConnect.Data.Abstraction.Repositories;
using InstaConnect.Data.Models.Entities;
using InstaConnect.Data.Repositories.Base;

namespace InstaConnect.Data.Repositories
{
    public class TokenRepository : Repository<Token>, ITokenRepository
    {
        private readonly InstaConnectContext _instaConnectContext;

        public TokenRepository(InstaConnectContext instaConnectContext) : base(instaConnectContext)
        {
            _instaConnectContext = instaConnectContext;
        }

        public async Task<Token?> GetByValueAsync(string value)
        {
            var token = await _.Tokens
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Value == value);

            return token;
        }
    }
}
