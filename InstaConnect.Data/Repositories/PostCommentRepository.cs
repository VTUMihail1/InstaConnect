using InstaConnect.Data.Abstraction.Repositories;
using InstaConnect.Data.Models.Entities;
using InstaConnect.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace InstaConnect.Data.Repositories
{
    public class PostCommentRepository : Repository<PostComment>, IPostCommentRepository
    {
        private readonly InstaConnectContext _instaConnectContext;

        public PostCommentRepository(InstaConnectContext instaConnectContext) : base(instaConnectContext)
        {
            _instaConnectContext = instaConnectContext;
        }

        public async Task<ICollection<PostComment>> GetAllIncludedAsync()
        {
            var postComments = await _instaConnectContext.PostComments
                .Include(pc => pc.CommentLikes)
                .Include(cl => cl.User)
                .Include(cl => cl.PostComments)
                .Include(pc => pc.CommentLikes)
                .ToListAsync();

            return postComments;
        }

        public async Task<ICollection<PostComment>> GetAllFilteredIncludedAsync(Expression<Func<PostComment, bool>> expression)
        {
            var postComments = await _instaConnectContext.PostComments
                .Where(expression)
                .Include(pc => pc.CommentLikes)
                .Include(cl => cl.User)
                .Include(cl => cl.PostComments)
                .Include(pc => pc.CommentLikes)
                .ToListAsync();

            return postComments;
        }

        public async Task<PostComment> FindIncludedAsync(Expression<Func<PostComment, bool>> expression)
        {
            var postComment = await _instaConnectContext.PostComments
                .Include(pc => pc.CommentLikes)
                .Include(cl => cl.User)
                .Include(cl => cl.PostComments)
                .Include(pc => pc.CommentLikes)
                .FirstOrDefaultAsync(expression);

            return postComment;
        }
    }
}
