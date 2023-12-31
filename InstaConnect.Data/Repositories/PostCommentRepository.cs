﻿using InstaConnect.Data.Abstraction.Repositories;
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

        public override async Task<ICollection<PostComment>> GetAllAsync(
            Expression<Func<PostComment, bool>> expression,
            int skipAmount = default,
            int takeAmount = int.MaxValue)
        {
            var postComments = await _instaConnectContext.PostComments
                .Where(expression)
                .Include(pc => pc.CommentLikes)
                .Include(cl => cl.User)
                .Include(cl => cl.PostComments)
                .Include(pc => pc.CommentLikes)
                .Skip(skipAmount)
                .Take(takeAmount)
                .AsNoTracking()
                .ToListAsync();

            return postComments;
        }

        public override async Task<PostComment> FindEntityAsync(Expression<Func<PostComment, bool>> expression)
        {
            var postComment = await _instaConnectContext.PostComments
                .Include(pc => pc.CommentLikes)
                .Include(cl => cl.User)
                .Include(cl => cl.PostComments)
                .Include(pc => pc.CommentLikes)
                .AsNoTracking()
                .FirstOrDefaultAsync(expression);

            return postComment;
        }
    }
}
