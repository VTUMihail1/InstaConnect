using InstaConnect.Data.Abstraction.Repositories;
using InstaConnect.Data.Models.Entities;
using InstaConnect.Data.Repositories.Base;

namespace InstaConnect.Data.Repositories
{
    public class FollowRepository : Repository<Follow>, IFollowRepository
    {
        public FollowRepository(InstaConnectContext instaConnectContext) : base(instaConnectContext)
        {
        }
    }
}
