using InstaConnect.Shared.Repositories;
using InstaConnect.Users.Data;
using InstaConnect.Users.Data.Abstraction.Repositories;
using InstaConnect.Users.Data.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace EGames.Data.Repositories
{
    internal class TokenRepository : BaseRepository<Token>, ITokenRepository
    {
        private readonly UsersContext _usersContext;

        public TokenRepository(UsersContext usersContext) : base(usersContext)
        {
            _usersContext = usersContext;
        }

        public async Task<Token?> GetByValueAsync(string value)
        {
            var token = await _usersContext.Tokens
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Value == value);

            return token;
        }
    }
}
