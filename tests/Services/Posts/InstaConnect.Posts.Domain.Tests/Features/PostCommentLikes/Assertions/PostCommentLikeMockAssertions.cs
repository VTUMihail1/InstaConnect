using InstaConnect.Common.Events.Features.Common.Abstractions;
using InstaConnect.Posts.Domain.Tests.Features.PostCommentLikes.Utilities;

namespace InstaConnect.Posts.Domain.Tests.Features.PostCommentLikes.Assertions;

public static class PostCommentLikeMockAssertions
{
	extension(IPostCommentLikeFactory factory)
	{
		public void ShouldReceiveOneCreate(
			AddPostCommentLikeCommand command)
		{
			factory.ShouldHaveReceivedOne().Create(
				command.CommentId,
				command.UserId);
		}
	}

	extension(IPostCommentLikeCommandRepository repository)
	{
		public async Task ShouldReceiveOneGetByIdAsync(
			PostCommentLike postCommentLike,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetByIdAsync(
				postCommentLike.Id,
				cancellationToken);
		}

		public async Task ShouldReceiveOneGetByIdAsync(
			DeletePostCommentLikeCommand command,
			PostCommentLikeInclude include,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetByIdAsync(
				command.Id,
				PostCommentLikeMatcher.IsPostCommentLikeInclude(command, include),
				cancellationToken);
		}

		public async Task ShouldReceiveOneAddAsync(
			AddPostCommentLikeCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().AddAsync(PostCommentLikeMatcher.IsPostCommentLike(command), cancellationToken);
		}

		public async Task ShouldReceiveOneDeleteAsync(
			DeletePostCommentLikeCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().DeleteAsync(PostCommentLikeMatcher.IsPostCommentLike(command), cancellationToken);
		}
	}

	extension(IPostCommandRepository repository)
	{
		public async Task ShouldReceiveOneExistsByIdAsync(
			AddPostCommentLikeCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().ExistsByIdAsync(
				command.CommentId.Id,
				cancellationToken);
		}

		public async Task ShouldReceiveOneExistsByIdAsync(
			DeletePostCommentLikeCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().ExistsByIdAsync(
				command.Id.CommentId.Id,
				cancellationToken);
		}
	}

	extension(IPostCommentCommandRepository repository)
	{
		public async Task ShouldReceiveOneGetByIdAsync(
			AddPostCommentLikeCommand command,
			PostCommentInclude include,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetByIdAsync(
				command.CommentId,
				PostCommentLikeMatcher.IsPostCommentInclude(command, include),
				cancellationToken);
		}

		public async Task ShouldReceiveOneExistsByIdAsync(
			DeletePostCommentLikeCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().ExistsByIdAsync(
				command.Id.CommentId,
				cancellationToken);
		}
	}

	extension(IUserCommandRepository repository)
	{
		public async Task ShouldReceiveOneGetByIdAsync(
			AddPostCommentLikeCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetByIdAsync(
				command.UserId,
				cancellationToken);
		}
	}

	extension(IPostQueryRepository repository)
	{
		public async Task ShouldReceiveOneExistsByIdAsync(
			GetAllPostCommentLikesQuery query,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().ExistsByIdAsync(
				query.Filter.CommentId.Id,
				cancellationToken);
		}

		public async Task ShouldReceiveOneExistsByIdAsync(
			GetPostCommentLikeByIdQuery query,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().ExistsByIdAsync(
				query.Id.CommentId.Id,
				cancellationToken);
		}
	}

	extension(IPostCommentQueryRepository repository)
	{
		public async Task ShouldReceiveOneGetByIdAsync(
			GetAllPostCommentLikesQuery query,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetByIdAsync(
				query.Filter.CommentId,
				query.CurrentUser,
				cancellationToken);
		}

		public async Task ShouldReceiveOneExistsByIdAsync(
			GetPostCommentLikeByIdQuery query,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().ExistsByIdAsync(
				query.Id.CommentId,
				cancellationToken);
		}
	}

	extension(IUserQueryRepository repository)
	{
		public async Task ShouldReceiveOneGetByIdAsync(
			GetAllPostCommentLikesForUserQuery query,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetByIdAsync(
				query.Filter.UserId,
				query.CurrentUser,
				cancellationToken);
		}
	}

	extension(IPostCommentLikeQueryRepository repository)
	{
		public async Task ShouldReceiveOneGetAllAsync(
			GetAllPostCommentLikesQuery query,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetAllAsync(
				query.Filter,
				query.CurrentUser,
				query.Sorting,
				query.Pagination,
				cancellationToken);
		}

		public async Task ShouldReceiveOneGetTotalCountAsync(
			GetAllPostCommentLikesQuery query,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetTotalCountAsync(
				query.Filter,
				cancellationToken);
		}

		public async Task ShouldReceiveOneGetAllForUserAsync(
			GetAllPostCommentLikesForUserQuery query,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetAllForUserAsync(
				query.Filter,
				query.CurrentUser,
				query.Sorting,
				query.Pagination,
				cancellationToken);
		}

		public async Task ShouldReceiveOneGetTotalCountForUserAsync(
			GetAllPostCommentLikesForUserQuery query,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetTotalCountForUserAsync(
				query.Filter,
				cancellationToken);
		}

		public async Task ShouldReceiveOneGetByIdAsync(
			GetPostCommentLikeByIdQuery query,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetByIdAsync(
				query.Id,
				query.CurrentUser,
				cancellationToken);
		}
	}

	extension(IEventPublisher eventPublisher)
	{
		public async Task ShouldReceiveOnePublishAsync(
			AddPostCommentLikeCommand command,
			PostCommentLike postCommentLike,
			CancellationToken cancellationToken)
		{
			await eventPublisher.ShouldHaveReceivedOne().PublishAsync(PostCommentLikeMatcher.IsPostCommentLikeAddedEventRequest(postCommentLike), cancellationToken);
		}

		public async Task ShouldReceiveOnePublishAsync(
			DeletePostCommentLikeCommand command,
			PostCommentLike postCommentLike,
			CancellationToken cancellationToken)
		{
			await eventPublisher.ShouldHaveReceivedOne().PublishAsync(PostCommentLikeMatcher.IsPostCommentLikeDeletedEventRequest(postCommentLike), cancellationToken);
		}
	}
}
