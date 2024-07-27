using InstaConnect.Identity.Data.Abstraction;
using InstaConnect.Identity.Data.Models.Entities;
using InstaConnect.Shared.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace InstaConnect.Identity.Data.Repositories;

internal class UserReadRepository : BaseReadRepository<User>, IUserReadRepository
{
    private readonly IdentityContext _identityContext;

    public UserReadRepository(IdentityContext identityContext) : base(identityContext)
    {
        _identityContext = identityContext;
    }

    public virtual async Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken)
    {
        var entity =
            await IncludeProperties(
            _identityContext.Users)
            .FirstOrDefaultAsync(u => u.Email == email, cancellationToken);

        return entity;
    }

    public virtual async Task<User?> GetByNameAsync(string name, CancellationToken cancellationToken)
    {
        var entity =
            await IncludeProperties(
            _identityContext.Users)
            .FirstOrDefaultAsync(u => u.UserName == name, cancellationToken);

        return entity;
    }
}
