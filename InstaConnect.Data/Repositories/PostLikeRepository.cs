using InstaConnect.Data.Abstraction.Repositories;
using InstaConnect.Data.Models.Entities;
using InstaConnect.Data.Repositories.Base;

namespace InstaConnect.Data.Repositories
{
    public class PostLikeRepository : Repository<PostLike>, IPostLikeRepository
    {
        public PostLikeRepository(InstaConnectContext instaConnectContext) : base(instaConnectContext)
        {
        }
    }
}
