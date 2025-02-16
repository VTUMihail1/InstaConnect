using InstaConnect.Identity.Domain.Features.Users.Abstractions;
using InstaConnect.Identity.Domain.Features.Users.Models.Entitites;

using Microsoft.EntityFrameworkCore;

namespace InstaConnect.Identity.Infrastructure.Features.Users.Repositories;

internal class UserWriteRepository : IUserWriteRepository
{
    private readonly IdentityContext _identityContext;

    public UserWriteRepository(IdentityContext identityContext)
    {
        _identityContext = identityContext;
    }

    public async Task<User?> GetByIdAsync(string id, CancellationToken cancellationToken)
    {
        var entity = await _identityContext
            .Users
            .Include(u => u.EmailConfirmationTokens)
            .Include(u => u.ForgotPasswordTokens)
            .FirstOrDefaultAsync(e => e.Id == id, cancellationToken);

        return entity;
    }

    public async Task<bool> AnyAsync(CancellationToken cancellationToken)
    {
        var any = await _identityContext
            .Users
            .AnyAsync(cancellationToken);

        return any;
    }

    public void Add(User entity)
    {
        _identityContext
            .Users
            .Add(entity);
    }

    public void Update(User user)
    {
        _identityContext
            .Users
            .Update(user);
    }

    public void Delete(User user)
    {
        _identityContext
            .Users
            .Remove(user);
    }

    public async Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken)
    {
        var entity = await _identityContext
            .Users
            .FirstOrDefaultAsync(u => u.Email == email, cancellationToken);

        return entity;
    }

    public async Task<User?> GetByNameAsync(string name, CancellationToken cancellationToken)
    {
        var entity = await _identityContext
            .Users
            .FirstOrDefaultAsync(u => u.UserName == name, cancellationToken);

        return entity;
    }

    public async Task ConfirmEmailAsync(string id, CancellationToken cancellationToken)
    {
        await _identityContext.Users
               .Where(u => u.Id == id)
               .ExecuteUpdateAsync(u => u.SetProperty(u => u.IsEmailConfirmed, true), cancellationToken);
    }

    public async Task ResetPasswordAsync(string id, string passwordHash, CancellationToken cancellationToken)
    {
        await _identityContext.Users
             .Where(u => u.Id == id)
             .ExecuteUpdateAsync(u => u.SetProperty(u => u.PasswordHash, passwordHash), cancellationToken);
    }
}
