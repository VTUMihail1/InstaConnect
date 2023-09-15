using InstaConnect.Data.Abstraction.Repositories;
using InstaConnect.Data.Models.Entities;
using InstaConnect.Data.Repositories.Base;

namespace InstaConnect.Data.Repositories
{
    public class LikeRepository : Repository<Like>, ILikeRepository
    {
        public LikeRepository(InstaConnectContext instaConnectContext) : base(instaConnectContext)
        {
        }
    }
}
