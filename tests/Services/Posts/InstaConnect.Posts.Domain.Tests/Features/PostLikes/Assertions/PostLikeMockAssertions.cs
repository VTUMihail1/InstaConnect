using InstaConnect.Common.Events.Features.Common.Abstractions;
using InstaConnect.Posts.Domain.Tests.Features.PostLikes.Utilities;

namespace InstaConnect.Posts.Domain.Tests.Features.PostLikes.Assertions;

public static class PostLikeMockAssertions
{
	extension(IPostLikeFactory factory)
	{
		public void ShouldReceiveOneCreate(
			AddPostLikeCommand command)
		{
			factory.ShouldHaveReceivedOne().Create(
				command.Id,
				command.UserId);
		}
	}

	extension(IPostLikeCommandRepository repository)
	{
		public async Task ShouldReceiveOneGetByIdAsync(
			PostLike postLike,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetByIdAsync(
				postLike.Id,
				cancellationToken);
		}

		public async Task ShouldReceiveOneGetByIdAsync(
			DeletePostLikeCommand command,
			PostLikeInclude include,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetByIdAsync(
				command.Id,
				PostLikeMatcher.IsPostLikeInclude(command, include),
				cancellationToken);
		}

		public async Task ShouldReceiveOneAddAsync(
			AddPostLikeCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().AddAsync(PostLikeMatcher.IsPostLike(command), cancellationToken);
		}

		public async Task ShouldReceiveOneDeleteAsync(
			DeletePostLikeCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().DeleteAsync(PostLikeMatcher.IsPostLike(command), cancellationToken);
		}
	}

	extension(IPostCommandRepository repository)
	{
		public async Task ShouldReceiveOneGetByIdAsync(
			AddPostLikeCommand command,
			PostInclude include,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetByIdAsync(
				command.Id,
				PostLikeMatcher.IsPostInclude(command, include),
				cancellationToken);
		}

		public async Task ShouldReceiveOneExistsByIdAsync(
			DeletePostLikeCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().ExistsByIdAsync(
				command.Id.Id,
				cancellationToken);
		}
	}

	extension(IUserCommandRepository repository)
	{
		public async Task ShouldReceiveOneGetByIdAsync(
			AddPostLikeCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetByIdAsync(
				command.UserId,
				cancellationToken);
		}
	}

	extension(IPostQueryRepository repository)
	{
		public async Task ShouldReceiveOneGetByIdAsync(
			GetAllPostLikesQuery query,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetByIdAsync(
				query.Filter.Id,
				query.CurrentUser,
				cancellationToken);
		}

		public async Task ShouldReceiveOneExistsByIdAsync(
			GetPostLikeByIdQuery query,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().ExistsByIdAsync(
				query.Id.Id,
				cancellationToken);
		}
	}

	extension(IUserQueryRepository repository)
	{
		public async Task ShouldReceiveOneGetByIdAsync(
			GetAllPostLikesForUserQuery query,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetByIdAsync(
				query.Filter.UserId,
				query.CurrentUser,
				cancellationToken);
		}
	}

	extension(IPostLikeQueryRepository repository)
	{
		public async Task ShouldReceiveOneGetAllAsync(
			GetAllPostLikesQuery query,
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
			GetAllPostLikesQuery query,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetTotalCountAsync(
				query.Filter,
				cancellationToken);
		}

		public async Task ShouldReceiveOneGetAllForUserAsync(
			GetAllPostLikesForUserQuery query,
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
			GetAllPostLikesForUserQuery query,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetTotalCountForUserAsync(
				query.Filter,
				cancellationToken);
		}

		public async Task ShouldReceiveOneGetByIdAsync(
			GetPostLikeByIdQuery query,
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
			AddPostLikeCommand command,
			PostLike postLike,
			CancellationToken cancellationToken)
		{
			await eventPublisher.ShouldHaveReceivedOne().PublishAsync(PostLikeMatcher.IsPostLikeAddedEventRequest(postLike), cancellationToken);
		}

		public async Task ShouldReceiveOnePublishAsync(
			DeletePostLikeCommand command,
			PostLike postLike,
			CancellationToken cancellationToken)
		{
			await eventPublisher.ShouldHaveReceivedOne().PublishAsync(PostLikeMatcher.IsPostLikeDeletedEventRequest(postLike), cancellationToken);
		}
	}
}
