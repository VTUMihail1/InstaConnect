using InstaConnect.Data.Abstraction.Repositories;
using InstaConnect.Data.Models.Entities;
using InstaConnect.Data.Repositories.Base;

namespace InstaConnect.Data.Repositories
{
    public class CommentLikeRepository : Repository<CommentLike>, ICommentLikeRepository
    {
        public CommentLikeRepository(InstaConnectContext instaConnectContext) : base(instaConnectContext)
        {
        }
    }
}
