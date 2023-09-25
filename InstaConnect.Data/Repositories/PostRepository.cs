using InstaConnect.Data.Abstraction.Repositories;
using InstaConnect.Data.Models.Entities;
using InstaConnect.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace InstaConnect.Data.Repositories
{
    public class PostRepository : Repository<Post>, IPostRepository
    {
        private readonly InstaConnectContext _instaConnectContext;

        public PostRepository(InstaConnectContext instaConnectContext) : base(instaConnectContext)
        {
            _instaConnectContext = instaConnectContext;
        }

        public override async Task<ICollection<Post>> GetAllAsync(Expression<Func<Post, bool>> expression)
        {
            var posts = await _instaConnectContext.Posts
                .Where(expression)
                .Include(p => p.User)
                .Include(p => p.PostComments)
                    .ThenInclude(pc => pc.CommentLikes)
                        .ThenInclude(cl => cl.User)
                        .ThenInclude(cl => cl.PostComments)
                            .ThenInclude(pc => pc.CommentLikes)
                .Include(p => p.PostLikes)
                    .ThenInclude(pl => pl.User)
                .ToListAsync();

            return posts;
        }

        public override async Task<Post> FindEntityAsync(Expression<Func<Post, bool>> expression)
        {
            var posts = await _instaConnectContext.Posts
                .Include(p => p.User)
                .Include(p => p.PostComments)
                    .ThenInclude(pc => pc.CommentLikes)
                        .ThenInclude(cl => cl.User)
                        .ThenInclude(cl => cl.PostComments)
                            .ThenInclude(pc => pc.CommentLikes)
                .Include(p => p.PostLikes)
                    .ThenInclude(pl => pl.User)
                .FirstOrDefaultAsync(expression);

            return posts;
        }
    }
}
