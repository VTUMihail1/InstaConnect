using InstaConnect.Data.Abstraction.Repositories;
using InstaConnect.Data.Models.Entities;
using InstaConnect.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;
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

        public override async Task<ICollection<CommentLike>> GetAllAsync(
            Expression<Func<CommentLike, bool>> expression,
            int skipAmount = default,
            int takeAmount = int.MaxValue)
        {
            var commentLikes = await _instaConnectContext.CommentLikes
                .Where(expression)
                .Include(cl => cl.User)
                .Skip(skipAmount)
                .Take(takeAmount)
                .ToListAsync();

            return commentLikes;
        }

        public override async Task<CommentLike> FindEntityAsync(Expression<Func<CommentLike, bool>> expression)
        {
            var commentLike = await _instaConnectContext.CommentLikes
                .Include(cl => cl.User)
                .FirstOrDefaultAsync(expression);

            return commentLike;
        }
    }
}
