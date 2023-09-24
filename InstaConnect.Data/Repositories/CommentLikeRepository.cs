using InstaConnect.Data.Abstraction.Repositories;
using InstaConnect.Data.Models.Entities;
using InstaConnect.Data.Repositories.Base;
using System.Linq.Expressions;

namespace InstaConnect.Data.Repositories
{
    public class CommentLikeRepository : Repository<CommentLike>, ICommentLikeRepository
    {
        private readonly InstaConnectContext _instaConnectContext;

        public CommentLikeRepository(InstaConnectContext instaConnectContext) : base(instaConnectContext)
        {
            _instaConnectContext = instaConnectContext;
        }

        public async Task<ICollection<CommentLike>> GetAllIncludedAsync()
        {
            // Implement the logic here
            throw new NotImplementedException();
        }

        public async Task<ICollection<CommentLike>> GetAllFilteredIncludedAsync(Expression<Func<CommentLike, bool>> expression)
        {
            // Implement the logic here
            throw new NotImplementedException();
        }

        public async Task<CommentLike> FindIncludedAsync(Expression<Func<CommentLike, bool>> expression)
        {
            // Implement the logic here
            throw new NotImplementedException();
        }
    }
}
