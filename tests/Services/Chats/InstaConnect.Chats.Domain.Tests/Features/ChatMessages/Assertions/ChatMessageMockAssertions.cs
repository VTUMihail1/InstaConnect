using InstaConnect.Chats.Domain.Tests.Features.ChatMessages.Utilities;
using InstaConnect.Common.Domain.Features.DateTimes.Abstractions;

namespace InstaConnect.Chats.Domain.Tests.Features.ChatMessages.Assertions;

public static class ChatMessageMockAssertions
{
	extension(IChatMessageFactory factory)
	{
		public void ShouldReceiveOneCreate(
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
		public async Task ShouldReceiveOneGetByIdAsync(
			AddChatMessageCommand command,
			ChatInclude include,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetByIdAsync(
				command.Id,
				ChatMessageDomainMatcher.IsChatInclude(command, include),
				cancellationToken);
		}

		public async Task ShouldReceiveOneExistsByIdAsync(
			UpdateChatMessageCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().ExistsByIdAsync(
				command.Id.Id,
				cancellationToken);
		}

		public async Task ShouldReceiveOneExistsByIdAsync(
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
		public async Task ShouldReceiveOneGetByIdAsync(
			UpdateChatMessageCommand command,
			ChatMessageInclude include,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetByIdAsync(
				command.Id,
				ChatMessageDomainMatcher.IsChatMessageInclude(command, include),
				cancellationToken);
		}

		public async Task ShouldReceiveOneGetByIdAsync(
			DeleteChatMessageCommand command,
			ChatMessageInclude include,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetByIdAsync(
				command.Id,
				ChatMessageDomainMatcher.IsChatMessageInclude(command, include),
				cancellationToken);
		}

		public async Task ShouldReceiveOneAddAsync(
			AddChatMessageCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().AddAsync(ChatMessageDomainMatcher.IsChatMessage(command), cancellationToken);
		}

		public async Task ShouldReceiveOneUpdateAsync(
			UpdateChatMessageCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().UpdateAsync(ChatMessageDomainMatcher.IsChatMessage(command), cancellationToken);
		}

		public async Task ShouldReceiveOneDeleteAsync(
			DeleteChatMessageCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().DeleteAsync(ChatMessageDomainMatcher.IsChatMessage(command), cancellationToken);
		}
	}

	extension(IChatQueryRepository repository)
	{
		public async Task ShouldReceiveOneGetByIdAsync(
			GetAllChatMessagesQuery query,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetByIdAsync(
				query.Filter.Id,
				query.CurrentUser,
				cancellationToken);
		}

		public async Task ShouldReceiveOneExistsByIdAsync(
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
		public async Task ShouldReceiveOneGetAllAsync(
			GetAllChatMessagesQuery query,
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
			GetAllChatMessagesQuery query,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetTotalCountAsync(
				query.Filter,
				cancellationToken);
		}

		public async Task ShouldReceiveOneGetByIdAsync(
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
		public void ShouldReceiveOneGetOffsetUtcNow(UpdateChatMessageCommand command)
		{
			dateTimeProvider.ShouldHaveReceivedOne().GetOffsetUtcNow();
		}
	}

	extension(IChatMessageNotificationService notificationService)
	{
		public async Task ShouldReceiveOneAddedAsync(
			AddChatMessageCommand command,
			ChatMessage chatMessage,
			CancellationToken cancellationToken)
		{
			await notificationService.ShouldHaveReceivedOne().AddedAsync(ChatMessageDomainMatcher.IsChatMessageAddedNotificationRequest(command, chatMessage), cancellationToken);
		}

		public async Task ShouldReceiveOneUpdatedAsync(
			UpdateChatMessageCommand command,
			ChatMessage chatMessage,
			CancellationToken cancellationToken)
		{
			await notificationService.ShouldHaveReceivedOne().UpdatedAsync(ChatMessageDomainMatcher.IsChatMessageUpdatedNotificationRequest(command, chatMessage), cancellationToken);
		}

		public async Task ShouldReceiveOneDeletedAsync(
			DeleteChatMessageCommand command,
			ChatMessage chatMessage,
			CancellationToken cancellationToken)
		{
			await notificationService.ShouldHaveReceivedOne().DeletedAsync(ChatMessageDomainMatcher.IsChatMessageDeletedNotificationRequest(command, chatMessage), cancellationToken);
		}
	}
}
