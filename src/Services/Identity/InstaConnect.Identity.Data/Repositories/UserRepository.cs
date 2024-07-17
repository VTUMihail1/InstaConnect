using InstaConnect.Identity.Data.Abstraction;
using InstaConnect.Identity.Data.Models.Entities;
using InstaConnect.Shared.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace InstaConnect.Identity.Data.Repositories;

internal class UserRepository : BaseReadRepository<User>, IUserRepository
{
    private readonly IdentityContext _identityContext;

    public UserRepository(IdentityContext identityContext) : base(identityContext)
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

    public virtual async Task ConfirmEmailAsync(string id, CancellationToken cancellationToken)
    {
        await _identityContext.Users
               .Where(u => u.Id == id)
               .ExecuteUpdateAsync(u => u.SetProperty(u => u.IsEmailConfirmed, true), cancellationToken);
    }

    public virtual async Task ResetPasswordAsync(string id, string passwordHash, CancellationToken cancellationToken)
    {
        await _identityContext.Users
             .Where(u => u.Id == id)
             .ExecuteUpdateAsync(u => u.SetProperty(u => u.PasswordHash, passwordHash), cancellationToken);
    }
}
