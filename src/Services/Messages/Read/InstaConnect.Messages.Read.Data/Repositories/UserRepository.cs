using InstaConnect.Messages.Read.Data.Abstractions;
using InstaConnect.Messages.Read.Data.Models.Entities;
using InstaConnect.Shared.Data.Repositories;

namespace InstaConnect.Messages.Read.Data.Repositories;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    private readonly MessagesContext _messagesContext;

    public UserRepository(MessagesContext messagesContext) : base(messagesContext)
    {
        _messagesContext = messagesContext;
    }
}
