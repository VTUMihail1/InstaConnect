using InstaConnect.Common.Domain.Features.DateTimes.Abstractions;
using InstaConnect.Common.Events.Features.Common.Abstractions;
using InstaConnect.Posts.Domain.Tests.Features.Posts.Utilities;

namespace InstaConnect.Posts.Domain.Tests.Features.Posts.Assertions;

public static class PostMockAssertions
{
	extension(IPostFactory factory)
	{
		public void ShouldReceiveOneCreate(
			AddPostCommand command)
		{
			factory.ShouldHaveReceivedOne().Create(
				command.UserId,
				command.Title,
				command.Content);
		}
	}

	extension(IPostQueryRepository repository)
	{
		public async Task ShouldReceiveOneGetAllAsync(
		GetAllPostsQuery query,
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
		GetAllPostsQuery query,
		CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetTotalCountAsync(
				query.Filter,
				cancellationToken);
		}

		public async Task ShouldReceiveOneGetAllForUserAsync(
			GetAllPostsForUserQuery query,
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
		GetAllPostsForUserQuery query,
		CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetTotalCountForUserAsync(
				query.Filter,
				cancellationToken);
		}

		public async Task ShouldReceiveOneGetByIdAsync(
			GetPostByIdQuery query,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetByIdAsync(
				query.Id,
				query.CurrentUser,
				cancellationToken);
		}
	}

	extension(IPostCommandRepository repository)
	{
		public async Task ShouldReceiveOneAddAsync(
		    AddPostCommand command,
		    CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().AddAsync(PostDomainMatcher.IsPost(command), cancellationToken);
		}

		public async Task ShouldReceiveOneUpdateAsync(
			UpdatePostCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().UpdateAsync(PostDomainMatcher.IsPost(command), cancellationToken);
		}

		public async Task ShouldReceiveOneDeleteAsync(
			DeletePostCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().DeleteAsync(PostDomainMatcher.IsPost(command), cancellationToken);
		}

		public async Task ShouldReceiveOneGetByIdAsync(
			UpdatePostCommand command,
			PostInclude include,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetByIdAsync(
				command.Id,
				PostDomainMatcher.IsPostInclude(command, include),
				cancellationToken);
		}

		public async Task ShouldReceiveOneGetByIdAsync(
			DeletePostCommand command,
			PostInclude include,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetByIdAsync(
				command.Id,
				PostDomainMatcher.IsPostInclude(command, include),
				cancellationToken);
		}
	}

	extension(IUserQueryRepository repository)
	{
		public async Task ShouldReceiveOneGetByIdAsync(
			GetAllPostsForUserQuery query,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetByIdAsync(
				query.Filter.UserId,
				query.CurrentUser,
				cancellationToken);
		}
	}

	extension(IUserCommandRepository repository)
	{
		public async Task ShouldReceiveOneGetByIdAsync(
			AddPostCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetByIdAsync(
				command.UserId,
				cancellationToken);
		}
	}

	extension(IDateTimeProvider dateTimeProvider)
	{
		public void ShouldReceiveOneGetOffsetUtcNow(UpdatePostCommand command)
		{
			dateTimeProvider.ShouldHaveReceivedOne().GetOffsetUtcNow();
		}
	}

	extension(IEventPublisher eventPublisher)
	{
		public async Task ShouldReceiveOnePublishAsync(
			AddPostCommand command,
			Post post,
			CancellationToken cancellationToken)
		{
			await eventPublisher.ShouldHaveReceivedOne().PublishAsync(PostDomainMatcher.IsPostAddedEventRequest(command, post), cancellationToken);
		}

		public async Task ShouldReceiveOnePublishAsync(
			UpdatePostCommand command,
			Post post,
			CancellationToken cancellationToken)
		{
			await eventPublisher.ShouldHaveReceivedOne().PublishAsync(PostDomainMatcher.IsPostUpdatedEventRequest(command, post), cancellationToken);
		}

		public async Task ShouldReceiveOnePublishAsync(
			DeletePostCommand command,
			Post post,
			CancellationToken cancellationToken)
		{
			await eventPublisher.ShouldHaveReceivedOne().PublishAsync(PostDomainMatcher.IsPostDeletedEventRequest(command, post), cancellationToken);
		}
	}
}
