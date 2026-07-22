using InstaConnect.Posts.Application.Features.PostCommentLikes.Models;
using InstaConnect.Posts.Application.Tests.Features.PostCommentLikes.Utilities;

using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Posts.Application.Tests.Features.PostCommentLikes.Utilities;

public static class PostCommentLikeSetups
{
	extension(IServiceScope serviceScope)
	{
		public async Task<PostCommentLike?> GetByIdAsync(
			PostCommentLikeIdCommandResponse id,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetByIdAsync(
				new PostCommentLikeId(
					new(
						new(id.Id),
						id.CommentId),
					new(id.UserId)),
				cancellationToken);
		}
	}
}
