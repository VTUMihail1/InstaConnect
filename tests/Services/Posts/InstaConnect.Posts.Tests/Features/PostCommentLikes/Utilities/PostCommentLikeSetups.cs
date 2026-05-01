using InstaConnect.Posts.Domain.Features.PostCommentLikes.Abstractions;
using InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.ValueObjects;
using InstaConnect.Posts.Tests.Features.PostComments.Utilities;
using InstaConnect.Posts.Tests.Features.Posts.Utilities;

using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Posts.Tests.Features.PostCommentLikes.Utilities;

public static class PostCommentLikeSetups
{
	extension(IServiceProvider serviceProvider)
	{
		public IPostCommentLikeCommandRepository GetPostCommentLikeCommandRepository()
		{
			return serviceProvider.GetRequiredService<IPostCommentLikeCommandRepository>();
		}

		public IPostCommentLikeIncludeBuilderFactory GetPostCommentLikeIncludeBuilderFactory()
		{
			return serviceProvider.GetRequiredService<IPostCommentLikeIncludeBuilderFactory>();
		}
	}

	extension(IServiceScope serviceScope)
	{
		public IPostCommentLikeCommandRepository GetPostCommentLikeCommandRepository()
		{
			return serviceScope.ServiceProvider.GetPostCommentLikeCommandRepository();
		}

		public IPostCommentLikeIncludeBuilderFactory GetPostCommentLikeIncludeBuilderFactory()
		{
			return serviceScope.ServiceProvider.GetPostCommentLikeIncludeBuilderFactory();
		}

		public async Task<PostCommentLike?> GetPostCommentLikeByIdAsync(
			PostCommentLikeId id,
			CancellationToken cancellationToken)
		{
			var include = serviceScope.GetPostIncludeBuilderFactory().Create().WithUser().Build();
			var commentInclude = serviceScope.GetPostCommentIncludeBuilderFactory().Create().WithUser().WithPost(include).Build();
			var commentLikeInclude = serviceScope.GetPostCommentLikeIncludeBuilderFactory().Create().WithPostComment(commentInclude).WithUser().Build();

			return await serviceScope.GetPostCommentLikeCommandRepository().GetByIdAsync(id, commentLikeInclude, cancellationToken);
		}

		public async Task AddPostCommentLikeAsync(
			PostCommentLike postCommentLike,
			CancellationToken cancellationToken)
		{
			await serviceScope.GetPostCommentLikeCommandRepository().AddAsync(postCommentLike, cancellationToken);
		}

		public async Task AddPostCommentLikeRangeAsync(
			IEnumerable<PostCommentLike> postCommentLikes,
			CancellationToken cancellationToken)
		{
			await serviceScope.GetPostCommentLikeCommandRepository().AddRangeAsync(postCommentLikes, cancellationToken);
		}

		public async Task DeletePostCommentLikeAsync(
			PostCommentLike postCommentLike,
			CancellationToken cancellationToken)
		{
			await serviceScope.GetPostCommentLikeCommandRepository().DeleteAsync(postCommentLike, cancellationToken);
		}
	}
}

