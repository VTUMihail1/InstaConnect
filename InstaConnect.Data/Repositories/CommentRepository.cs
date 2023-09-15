using InstaConnect.Data.Models.Entities;
using InstaConnect.Data.Repositories.Base;

namespace InstaConnect.Data.Repositories
{
    public class CommentRepository : Repository<Comment>
    {
        public CommentRepository(InstaConnectContext instaConnectContext) : base(instaConnectContext)
        {
        }
    }
}
