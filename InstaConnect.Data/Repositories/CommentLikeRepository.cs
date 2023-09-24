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

        public async Task<ICollection<CommentLike>> GetAllIncludedAsync()
        {
            var commentsLikes = await _instaConnectContext.CommentLikes
                .Include(cl => cl.User)
                .ToListAsync();

            return commentsLikes;
        }

        public async Task<ICollection<CommentLike>> GetAllFilteredIncludedAsync(Expression<Func<CommentLike, bool>> expression)
        {
            var commentsLikes = await _instaConnectContext.CommentLikes
                .Where(expression)
                .Include(cl => cl.User)
                .ToListAsync();

            return commentsLikes;
        }

        public async Task<CommentLike> FindCommentLikeIncludedAsync(Expression<Func<CommentLike, bool>> expression)
        {
            var commentsLike = await _instaConnectContext.CommentLikes
                .Include(cl => cl.User)
                .FirstOrDefaultAsync(expression);

            return commentsLike;
        }
    }
}
