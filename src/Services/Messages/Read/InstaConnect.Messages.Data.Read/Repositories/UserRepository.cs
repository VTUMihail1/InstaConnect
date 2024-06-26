using InstaConnect.Messages.Data.Read;
using InstaConnect.Messages.Data.Read.Abstractions;
using InstaConnect.Messages.Data.Read.Models.Entities;
using InstaConnect.Shared.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace InstaConnect.Messages.Data.Read.Repositories;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    private readonly MessagesContext _messagesContext;

    public UserRepository(MessagesContext messagesContext) : base(messagesContext)
    {
        _messagesContext = messagesContext;
    }
}
