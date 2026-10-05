using InstaConnect.Common.Domain.Features.DateTimes.Abstractions;
using InstaConnect.Common.Events.Features.Events.Abstractions;
using InstaConnect.Posts.Domain.Tests.Features.PostComments.Utilities;

namespace InstaConnect.Posts.Domain.Tests.Features.PostComments.Assertions;

public static class PostCommentMockAssertions
{
	extension(IPostCommentFactory factory)
	{
		public void ShouldHaveReceivedOneCreate(
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
		public async Task ShouldHaveReceivedOneGetByIdAsync(
			AddPostCommentCommand command,
			PostInclude include,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetByIdAsync(
				command.Id,
				include,
				cancellationToken);
		}

		public async Task ShouldHaveReceivedOneExistsByIdAsync(
			UpdatePostCommentCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().ExistsByIdAsync(
				command.Id.Id,
				cancellationToken);
		}

		public async Task ShouldHaveReceivedOneExistsByIdAsync(
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
		public async Task ShouldHaveReceivedOneGetByIdAsync(
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
		public async Task ShouldHaveReceivedOneGetByIdAsync(
			UpdatePostCommentCommand command,
			PostCommentInclude include,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetByIdAsync(
				command.Id,
				include,
				cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetByIdAsync(
			DeletePostCommentCommand command,
			PostCommentInclude include,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetByIdAsync(
				command.Id,
				include,
				cancellationToken);
		}

		public async Task ShouldHaveReceivedOneAddAsync(
			AddPostCommentCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().AddAsync(command.IsPostComment(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneUpdateAsync(
			UpdatePostCommentCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().UpdateAsync(command.IsPostComment(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneDeleteAsync(
			DeletePostCommentCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().DeleteAsync(command.IsPostComment(), cancellationToken);
		}
	}

	extension(IPostQueryRepository repository)
	{
		public async Task ShouldHaveReceivedOneGetByIdAsync(
			GetAllPostCommentsQuery query,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetByIdAsync(
				query.Filter.Id,
				query.CurrentUser,
				cancellationToken);
		}

		public async Task ShouldHaveReceivedOneExistsByIdAsync(
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
		public async Task ShouldHaveReceivedOneGetByIdAsync(
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
		public async Task ShouldHaveReceivedOneGetAllAsync(
			GetAllPostCommentsQuery query,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetAllAsync(
				query.Filter,
				query.Sorting,
				query.Pagination,
				query.CurrentUser,
				cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetTotalCountAsync(
			GetAllPostCommentsQuery query,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetTotalCountAsync(
				query.Filter,
				cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetAllForUserAsync(
			GetAllPostCommentsForUserQuery query,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetAllForUserAsync(
				query.Filter,
				query.Sorting,
				query.Pagination,
				query.CurrentUser,
				cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetTotalCountForUserAsync(
			GetAllPostCommentsForUserQuery query,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetTotalCountForUserAsync(
				query.Filter,
				cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetByIdAsync(
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
		public void ShouldHaveReceivedOneGetOffsetUtcNow(UpdatePostCommentCommand command)
		{
			dateTimeProvider.ShouldHaveReceivedOne().GetOffsetUtcNow();
		}
	}

	extension(IEventPublisher eventPublisher)
	{
		public async Task ShouldHaveReceivedOnePublishAsync(
			AddPostCommentCommand command,
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			await eventPublisher.ShouldHaveReceivedOne().PublishAsync(command.IsPostCommentAddedEventRequest(postComment), cancellationToken);
		}

		public async Task ShouldHaveReceivedOnePublishAsync(
			UpdatePostCommentCommand command,
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			await eventPublisher.ShouldHaveReceivedOne().PublishAsync(command.IsPostCommentUpdatedEventRequest(postComment), cancellationToken);
		}

		public async Task ShouldHaveReceivedOnePublishAsync(
			DeletePostCommentCommand command,
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			await eventPublisher.ShouldHaveReceivedOne().PublishAsync(command.IsPostCommentDeletedEventRequest(postComment), cancellationToken);
		}
	}
}
