using InstaConnect.Messages.Data;
using InstaConnect.Messages.Data.Abstractions;
using InstaConnect.Messages.Data.Models.Entities;
using InstaConnect.Shared.Data.Repositories;

namespace InstaConnect.Messages.Data.Repositories;

internal class UserWriteRepository : BaseWriteRepository<User>, IUserWriteRepository
{
    public UserWriteRepository(MessagesContext messageContext) : base(messageContext)
    {
    }
}
