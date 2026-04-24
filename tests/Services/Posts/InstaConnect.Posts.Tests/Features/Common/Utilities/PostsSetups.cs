using InstaConnect.Common.Tests.Features.Extensions;
using InstaConnect.Posts.Infrastructure.Features.Common.Abstractions;

using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Posts.Tests.Features.Common.Utilities;

public static class PostsSetups
{

    extension(IServiceProvider serviceProvider)
    {
        public IPostsContext GetPostsContext()
        {
            return serviceProvider.GetRequiredService<IPostsContext>();
        }
    }

    extension(IServiceScope serviceScope)
    {
        public IPostsContext GetPostsContext()
        {
            return serviceScope.ServiceProvider.GetPostsContext();
        }

        public async Task ResetPostsDatabase(
            CancellationToken cancellationToken)
        {
            var context = serviceScope.GetPostsContext();

            await context.PostCommentLikes.ResetAsync(cancellationToken);
            await context.PostComments.ResetAsync(cancellationToken);
            await context.PostLikes.ResetAsync(cancellationToken);
            await context.Posts.ResetAsync(cancellationToken);
            await context.Users.ResetAsync(cancellationToken);
        }
    }
}
