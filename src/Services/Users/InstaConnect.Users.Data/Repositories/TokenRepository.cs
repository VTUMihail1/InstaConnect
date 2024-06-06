using InstaConnect.Shared.Data.Repositories;
using InstaConnect.Users.Data.Abstraction.Repositories;
using InstaConnect.Users.Data.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace InstaConnect.Users.Data.Repositories;

internal class TokenRepository : BaseRepository<Token>, ITokenRepository
{
    private readonly UsersContext _usersContext;

    public TokenRepository(UsersContext usersContext) : base(usersContext)
    {
        _usersContext = usersContext;
    }

    public async Task<Token?> GetByValueAsync(string value, CancellationToken cancellationToken)
    {
        var token = await _usersContext.Tokens
            .FirstOrDefaultAsync(e => e.Value == value, cancellationToken);

        return token;
    }
}
