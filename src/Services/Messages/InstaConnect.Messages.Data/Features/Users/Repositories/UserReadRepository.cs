using InstaConnect.Messages.Data.Features.Users.Abstract;
using InstaConnect.Messages.Data.Features.Users.Models.Entities;
using InstaConnect.Shared.Data.Repositories;

namespace InstaConnect.Messages.Data.Features.Users.Repositories;

internal class UserReadRepository : BaseReadRepository<User>, IUserReadRepository
{
    public UserReadRepository(MessagesContext messagesContext) : base(messagesContext)
    {
    }
}
