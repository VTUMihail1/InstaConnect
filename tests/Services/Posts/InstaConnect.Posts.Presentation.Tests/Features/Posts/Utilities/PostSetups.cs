using InstaConnect.Posts.Presentation.Tests.Features.Posts.Utilities;

using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Posts.Presentation.Tests.Features.Posts.Utilities;

public static class PostSetups
{
    extension(IServiceScope serviceScope)
    {
        public async Task<Post?> GetPostByIdAsync(
        PostIdApiResponse id,
        CancellationToken cancellationToken)
        {
            return await serviceScope.GetPostByIdAsync(
                new PostId(id.Id),
                cancellationToken);
        }
    }
}
