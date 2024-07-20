using InstaConnect.Messages.Data;
using InstaConnect.Messages.Data.Abstractions;
using InstaConnect.Messages.Data.Models.Entities;
using InstaConnect.Shared.Data.Repositories;

namespace InstaConnect.Messages.Data.Repositories;

internal class UserReadRepository : BaseReadRepository<User>, IUserReadRepository
{
    public UserReadRepository(MessagesContext messagesContext) : base(messagesContext)
    {
    }
}
