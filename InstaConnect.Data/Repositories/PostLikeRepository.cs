using InstaConnect.Data.Abstraction.Repositories;
using InstaConnect.Data.Models.Entities;
using InstaConnect.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace InstaConnect.Data.Repositories
{
    public class PostLikeRepository : Repository<PostLike>, IPostLikeRepository
    {
        private readonly InstaConnectContext _instaConnectContext;

        public PostLikeRepository(InstaConnectContext instaConnectContext) : base(instaConnectContext)
        {
            _instaConnectContext = instaConnectContext;
        }

        public async Task<ICollection<PostLike>> GetAllIncludedAsync()
        {
            var postLikes = await _instaConnectContext.PostLikes
                .Include(f => f.User)
                .Include(f => f.Post)
                .ToListAsync();

            return postLikes;
        }

        public async Task<ICollection<PostLike>> GetAllFilteredIncludedAsync(Expression<Func<PostLike, bool>> expression)
        {
            var postLikes = await _instaConnectContext.PostLikes
                .Where(expression)
                .Include(f => f.User)
                .Include(f => f.Post)
                .ToListAsync();

            return postLikes;
        }

        public async Task<PostLike> FindPostLikeIncludedAsync(Expression<Func<PostLike, bool>> expression)
        {
            var postLike = await _instaConnectContext.PostLikes
                .Include(f => f.User)
                .Include(f => f.Post)
                .FirstOrDefaultAsync(expression);

            return postLike;
        }
    }
}
