using InstaConnect.Posts.Application.Features.PostLikes.Models;

using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Posts.Application.Tests.Features.PostLikes.Utilities;

public static class PostLikeSetups
{
	extension(IServiceScope serviceScope)
	{
		public async Task<PostLike?> GetPostLikeByIdAsync(
		PostLikeIdCommandResponse id,
		CancellationToken cancellationToken)
		{
			return await serviceScope.GetPostLikeByIdAsync(
				new PostLikeId(
							   new(id.Id),
							   new(id.UserId)),
				cancellationToken);
		}
	}
}
