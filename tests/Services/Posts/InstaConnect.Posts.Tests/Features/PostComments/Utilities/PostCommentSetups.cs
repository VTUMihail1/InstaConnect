using InstaConnect.Common.Tests.Extensions;
using InstaConnect.Posts.Domain.Features.PostComments.Abstractions;
using InstaConnect.Posts.Domain.Features.PostComments.Models.ValueObjects;
using InstaConnect.Posts.Infrastructure.Abstractions;
using InstaConnect.Posts.Tests.Features.Posts.Utilities;

using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Posts.Tests.Features.PostComments.Utilities;

public static class PostCommentSetups
{
    extension(IServiceScope serviceScope)
    {
        public IPostCommentCommandRepository GetPostCommentCommandRepository()
        {
            return serviceScope.ServiceProvider.GetRequiredService<IPostCommentCommandRepository>();
        }

        public IPostCommentIncludeBuilderFactory GetPostCommentIncludeBuilderFactory()
        {
            return serviceScope.ServiceProvider.GetRequiredService<IPostCommentIncludeBuilderFactory>();
        }

        public async Task<PostComment?> GetPostCommentByIdAsync(
            PostCommentId id,
            CancellationToken cancellationToken)
        {
            var include = serviceScope.GetPostIncludeBuilderFactory().Create().WithUser().Build();
            var commentInclude = serviceScope.GetPostCommentIncludeBuilderFactory().Create().WithUser().WithPost(include).Build();
            var postCommentRepository = serviceScope.GetPostCommentCommandRepository();

            return await postCommentRepository.GetByIdAsync(id, commentInclude, cancellationToken);
        }

        public async Task AddPostCommentAsync(
            PostComment postComment,
            CancellationToken cancellationToken)
        {
            var postCommentRepository = serviceScope.GetPostCommentCommandRepository();

            await postCommentRepository.AddAsync(postComment, cancellationToken);
        }

        public async Task AddPostCommentRangeAsync(
            IEnumerable<PostComment> postComments,
            CancellationToken cancellationToken)
        {
            var postCommentRepository = serviceScope.GetPostCommentCommandRepository();

            await postCommentRepository.AddRangeAsync(postComments, cancellationToken);
        }

        public async Task DeletePostCommentAsync(
            PostComment postComment,
            CancellationToken cancellationToken)
        {
            var postCommentRepository = serviceScope.GetPostCommentCommandRepository();

            await postCommentRepository.DeleteAsync(postComment, cancellationToken);
        }

        public async Task ResetPostCommentDatabase(
            CancellationToken cancellationToken)
        {
            var context = serviceScope.ServiceProvider.GetRequiredService<IPostsContext>();

            await context.PostCommentLikes.ResetAsync(cancellationToken);
            await context.PostComments.ResetAsync(cancellationToken);
            await context.PostLikes.ResetAsync(cancellationToken);
            await context.Posts.ResetAsync(cancellationToken);
            await context.Users.ResetAsync(cancellationToken);
        }
    }
}
