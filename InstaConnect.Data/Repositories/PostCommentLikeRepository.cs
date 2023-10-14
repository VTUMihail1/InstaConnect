using InstaConnect.Data.Abstraction.Repositories;
using InstaConnect.Data.Models.Entities;
using InstaConnect.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace InstaConnect.Data.Repositories
{
    public class PostCommentLikeRepository : Repository<PostCommentLike>, IPostCommentLikeRepository
    {
        private readonly InstaConnectContext _instaConnectContext;

        public PostCommentLikeRepository(InstaConnectContext instaConnectContext) : base(instaConnectContext)
        {
            _instaConnectContext = instaConnectContext;
        }

        public override async Task<ICollection<PostCommentLike>> GetAllAsync(
            Expression<Func<PostCommentLike, bool>> expression,
            int skipAmount = default,
            int takeAmount = int.MaxValue)
        {
            var commentLikes = await _instaConnectContext.PostCommentLikes
                .Where(expression)
                .Include(cl => cl.User)
                .Skip(skipAmount)
                .Take(takeAmount)
                .AsNoTracking()
                .ToListAsync();

            return commentLikes;
        }

        public override async Task<PostCommentLike> FindEntityAsync(Expression<Func<PostCommentLike, bool>> expression)
        {
            var commentLike = await _instaConnectContext.PostCommentLikes
                .Include(cl => cl.User)
                .AsNoTracking()
                .FirstOrDefaultAsync(expression);

            return commentLike;
        }
    }
}
