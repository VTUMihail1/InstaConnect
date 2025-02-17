using InstaConnect.Messages.Domain.Features.Users.Models.Entities;

using Microsoft.EntityFrameworkCore;

namespace InstaConnect.Messages.Infrastructure.Features.Users.Repositories;

internal class UserWriteRepository : IUserWriteRepository
{
    private readonly MessagesContext _messageContext;

    public UserWriteRepository(MessagesContext messageContext)
    {
        _messageContext = messageContext;
    }

    public async Task<User?> GetByIdAsync(string id, CancellationToken cancellationToken)
    {
        var user = await _messageContext
            .Users
            .FirstOrDefaultAsync(e => e.Id == id, cancellationToken);

        return user;
    }

    public void Add(User user)
    {
        _messageContext
            .Users
            .Add(user);
    }

    public void Update(User user)
    {
        _messageContext
            .Users
            .Update(user);
    }

    public void Delete(User user)
    {
        _messageContext
            .Users
            .Remove(user);
    }
}
