using InstaConnect.Messages.Read.Data.Abstractions;
using InstaConnect.Messages.Read.Data.Models.Entities;
using InstaConnect.Shared.Data.Repositories;

namespace InstaConnect.Messages.Read.Data.Repositories;

internal class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(MessagesContext messagesContext) : base(messagesContext)
    {
    }
}
