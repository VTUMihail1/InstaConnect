using InstaConnect.Data.Models.Entities;
using InstaConnect.Data.Repositories.Base;

namespace InstaConnect.Data.Repositories
{
    public class LikeRepository : Repository<Like>
    {
        public LikeRepository(InstaConnectContext instaConnectContext) : base(instaConnectContext)
        {
        }
    }
}
