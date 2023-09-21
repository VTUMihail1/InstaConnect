using InstaConnect.Data.Abstraction.Repositories;
using InstaConnect.Data.Models.Entities;
using InstaConnect.Data.Repositories.Base;

namespace InstaConnect.Data.Repositories
{
    public class MessageRepository : Repository<Message>, IMessageRepository
    {
        public MessageRepository(InstaConnectContext instaConnectContext) : base(instaConnectContext)
        {
        }
    }
}
