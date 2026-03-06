using InstaConnect.Posts.Application.Features.Posts.Models;
using InstaConnect.Posts.Domain.Features.Posts.Models.ValueObjects;

using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Posts.Application.Tests.Features.Posts.Utilities;

public static class PostSetups
{
    extension(IServiceScope serviceScope)
    {
        public async Task<Post?> GetPostByIdAsync(
        PostIdCommandResponse id,
        CancellationToken cancellationToken)
        {
            return await serviceScope.GetPostByIdAsync(
                new PostId(id.Id),
                cancellationToken);
        }
    }
}
