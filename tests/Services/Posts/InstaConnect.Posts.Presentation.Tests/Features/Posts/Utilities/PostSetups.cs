using InstaConnect.Posts.Domain.Features.Posts.Models.ValueObjects;
using InstaConnect.Posts.Presentation.Tests.Features.Posts.Utilities;

using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Posts.Presentation.Tests.Features.Posts.Utilities;
public static class PostSetups
{
    public static async Task<Post?> GetPostByIdAsync(
        this IServiceScope serviceScope,
        PostIdApiResponse id,
        CancellationToken cancellationToken)
    {
        return await serviceScope.GetPostByIdAsync(
            new PostId(id.Id),
            cancellationToken);
    }
}
