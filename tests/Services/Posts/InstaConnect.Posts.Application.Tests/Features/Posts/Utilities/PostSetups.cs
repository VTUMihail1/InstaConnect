using InstaConnect.Posts.Application.Features.Posts.Models;
using InstaConnect.Posts.Domain.Features.Posts.Models.ValueObjects;

using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Posts.Application.Tests.Features.Posts.Utilities;
public static class PostSetups
{
    public static async Task<Post?> GetPostByIdAsync(
        this IServiceScope serviceScope,
        PostIdCommandResponse id,
        CancellationToken cancellationToken)
    {
        return await serviceScope.GetPostByIdAsync(
            new PostId(id.Id),
            cancellationToken);
    }
}
