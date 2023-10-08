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


        public override async Task<ICollection<PostLike>> GetAllAsync(
            Expression<Func<PostLike, bool>> expression,
            int skipAmount = default,
            int takeAmount = int.MaxValue)
        {
            var postLikes = await _instaConnectContext.PostLikes
                .Where(expression)
                .Include(f => f.User)
                .Include(f => f.Post)
                .Skip(skipAmount)
                .Take(takeAmount)
                .ToListAsync();

            return postLikes;
        }

        public override async Task<PostLike> FindEntityAsync(Expression<Func<PostLike, bool>> expression)
        {
            var postLike = await _instaConnectContext.PostLikes
                .Include(f => f.User)
                .Include(f => f.Post)
                .FirstOrDefaultAsync(expression);

            return postLike;
        }
    }
}
