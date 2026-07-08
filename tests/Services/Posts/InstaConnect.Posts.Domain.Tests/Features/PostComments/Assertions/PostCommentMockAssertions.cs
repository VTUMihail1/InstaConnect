using InstaConnect.Common.Domain.Features.DateTimes.Abstractions;
using InstaConnect.Common.Events.Features.Common.Abstractions;
using InstaConnect.Posts.Domain.Tests.Features.PostComments.Utilities;

namespace InstaConnect.Posts.Domain.Tests.Features.PostComments.Assertions;

public static class PostCommentMockAssertions
{
	extension(IPostCommentFactory factory)
	{
		public void ShouldReceiveOneCreate(
			AddPostCommentCommand command)
		{
			factory.ShouldHaveReceivedOne().Create(
				command.Id,
				command.UserId,
				command.Content);
		}
	}

	extension(IPostCommandRepository repository)
	{
		public async Task ShouldReceiveOneGetByIdAsync(
			AddPostCommentCommand command,
			PostInclude include,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetByIdAsync(
				command.Id,
				PostCommentMatcher.IsPostInclude(command, include),
				cancellationToken);
		}

		public async Task ShouldReceiveOneExistsByIdAsync(
			UpdatePostCommentCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().ExistsByIdAsync(
				command.Id.Id,
				cancellationToken);
		}

		public async Task ShouldReceiveOneExistsByIdAsync(
			DeletePostCommentCommand command,
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
			AddPostCommentCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetByIdAsync(
				command.UserId,
				cancellationToken);
		}
	}

	extension(IPostCommentCommandRepository repository)
	{
		public async Task ShouldReceiveOneGetByIdAsync(
			UpdatePostCommentCommand command,
			PostCommentInclude include,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetByIdAsync(
				command.Id,
				PostCommentMatcher.IsPostCommentInclude(command, include),
				cancellationToken);
		}

		public async Task ShouldReceiveOneGetByIdAsync(
			DeletePostCommentCommand command,
			PostCommentInclude include,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetByIdAsync(
				command.Id,
				PostCommentMatcher.IsPostCommentInclude(command, include),
				cancellationToken);
		}

		public async Task ShouldReceiveOneAddAsync(
			AddPostCommentCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().AddAsync(PostCommentMatcher.IsPostComment(command), cancellationToken);
		}

		public async Task ShouldReceiveOneUpdateAsync(
			UpdatePostCommentCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().UpdateAsync(PostCommentMatcher.IsPostComment(command), cancellationToken);
		}

		public async Task ShouldReceiveOneDeleteAsync(
			DeletePostCommentCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().DeleteAsync(PostCommentMatcher.IsPostComment(command), cancellationToken);
		}
	}

	extension(IPostQueryRepository repository)
	{
		public async Task ShouldReceiveOneGetByIdAsync(
			GetAllPostCommentsQuery query,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetByIdAsync(
				query.Filter.Id,
				query.CurrentUser,
				cancellationToken);
		}

		public async Task ShouldReceiveOneExistsByIdAsync(
			GetPostCommentByIdQuery query,
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
			GetAllPostCommentsForUserQuery query,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetByIdAsync(
				query.Filter.UserId,
				query.CurrentUser,
				cancellationToken);
		}
	}

	extension(IPostCommentQueryRepository repository)
	{
		public async Task ShouldReceiveOneGetAllAsync(
			GetAllPostCommentsQuery query,
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
			GetAllPostCommentsQuery query,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetTotalCountAsync(
				query.Filter,
				cancellationToken);
		}

		public async Task ShouldReceiveOneGetAllForUserAsync(
			GetAllPostCommentsForUserQuery query,
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
			GetAllPostCommentsForUserQuery query,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetTotalCountForUserAsync(
				query.Filter,
				cancellationToken);
		}

		public async Task ShouldReceiveOneGetByIdAsync(
			GetPostCommentByIdQuery query,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetByIdAsync(
				query.Id,
				query.CurrentUser,
				cancellationToken);
		}
	}

	extension(IDateTimeProvider dateTimeProvider)
	{
		public void ShouldReceiveOneGetOffsetUtcNow(UpdatePostCommentCommand command)
		{
			dateTimeProvider.ShouldHaveReceivedOne().GetOffsetUtcNow();
		}
	}

	extension(IEventPublisher eventPublisher)
	{
		public async Task ShouldReceiveOnePublishAsync(
			AddPostCommentCommand command,
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			await eventPublisher.ShouldHaveReceivedOne().PublishAsync(PostCommentMatcher.IsPostCommentAddedEventRequest(command, postComment), cancellationToken);
		}

		public async Task ShouldReceiveOnePublishAsync(
			UpdatePostCommentCommand command,
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			await eventPublisher.ShouldHaveReceivedOne().PublishAsync(PostCommentMatcher.IsPostCommentUpdatedEventRequest(command, postComment), cancellationToken);
		}

		public async Task ShouldReceiveOnePublishAsync(
			DeletePostCommentCommand command,
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			await eventPublisher.ShouldHaveReceivedOne().PublishAsync(PostCommentMatcher.IsPostCommentDeletedEventRequest(command, postComment), cancellationToken);
		}
	}
}
