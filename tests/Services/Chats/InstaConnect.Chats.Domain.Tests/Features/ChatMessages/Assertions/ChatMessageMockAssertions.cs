using InstaConnect.Chats.Domain.Tests.Features.ChatMessages.Utilities;
using InstaConnect.Common.Domain.Features.DateTimes.Abstractions;

namespace InstaConnect.Chats.Domain.Tests.Features.ChatMessages.Assertions;

public static class ChatMessageMockAssertions
{
	extension(IChatMessageFactory factory)
	{
		public void ShouldHaveReceivedOneCreate(
			AddChatMessageCommand command)
		{
			factory.ShouldHaveReceivedOne().Create(
				command.Id,
				command.Id.ParticipantOneId,
				command.Content);
		}
	}

	extension(IChatCommandRepository repository)
	{
		public async Task ShouldHaveReceivedOneGetByIdAsync(
			AddChatMessageCommand command,
			ChatInclude include,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetByIdAsync(
				command.Id,
				include,
				cancellationToken);
		}

		public async Task ShouldHaveReceivedOneExistsByIdAsync(
			UpdateChatMessageCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().ExistsByIdAsync(
				command.Id.Id,
				cancellationToken);
		}

		public async Task ShouldHaveReceivedOneExistsByIdAsync(
			DeleteChatMessageCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().ExistsByIdAsync(
				command.Id.Id,
				cancellationToken);
		}
	}

	extension(IChatMessageCommandRepository repository)
	{
		public async Task ShouldHaveReceivedOneGetByIdAsync(
			UpdateChatMessageCommand command,
			ChatMessageInclude include,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetByIdAsync(
				command.Id,
				include,
				cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetByIdAsync(
			DeleteChatMessageCommand command,
			ChatMessageInclude include,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetByIdAsync(
				command.Id,
				include,
				cancellationToken);
		}

		public async Task ShouldHaveReceivedOneAddAsync(
			AddChatMessageCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().AddAsync(command.IsChatMessage(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneUpdateAsync(
			UpdateChatMessageCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().UpdateAsync(command.IsChatMessage(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneDeleteAsync(
			DeleteChatMessageCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().DeleteAsync(command.IsChatMessage(), cancellationToken);
		}
	}

	extension(IChatQueryRepository repository)
	{
		public async Task ShouldHaveReceivedOneGetByIdAsync(
			GetAllChatMessagesQuery query,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetByIdAsync(
				query.Filter.Id,
				query.CurrentUser,
				cancellationToken);
		}

		public async Task ShouldHaveReceivedOneExistsByIdAsync(
			GetChatMessageByIdQuery query,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().ExistsByIdAsync(
				query.Id.Id,
				cancellationToken);
		}
	}

	extension(IChatMessageQueryRepository repository)
	{
		public async Task ShouldHaveReceivedOneGetAllAsync(
			GetAllChatMessagesQuery query,
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
			GetAllChatMessagesQuery query,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetTotalCountAsync(
				query.Filter,
				cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetByIdAsync(
			GetChatMessageByIdQuery query,
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
		public void ShouldHaveReceivedOneGetOffsetUtcNow(UpdateChatMessageCommand command)
		{
			dateTimeProvider.ShouldHaveReceivedOne().GetOffsetUtcNow();
		}
	}

	extension(IChatMessageNotificationService notificationService)
	{
		public async Task ShouldHaveReceivedOneAddedAsync(
			AddChatMessageCommand command,
			ChatMessage chatMessage,
			CancellationToken cancellationToken)
		{
			await notificationService.ShouldHaveReceivedOne().AddedAsync(command.IsChatMessageAddedNotificationRequest(chatMessage), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneUpdatedAsync(
			UpdateChatMessageCommand command,
			ChatMessage chatMessage,
			CancellationToken cancellationToken)
		{
			await notificationService.ShouldHaveReceivedOne().UpdatedAsync(command.IsChatMessageUpdatedNotificationRequest(chatMessage), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneDeletedAsync(
			DeleteChatMessageCommand command,
			ChatMessage chatMessage,
			CancellationToken cancellationToken)
		{
			await notificationService.ShouldHaveReceivedOne().DeletedAsync(command.IsChatMessageDeletedNotificationRequest(chatMessage), cancellationToken);
		}
	}
}
