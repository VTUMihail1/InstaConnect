using InstaConnect.Common.Domain.Features.DateTimes.Abstractions;
using InstaConnect.Common.Domain.Features.Guids.Abstractions;

namespace InstaConnect.Chats.Domain.Tests.Features.ChatMessages.Utilities;

public static class ChatMessageMockSetups
{
	extension(IGuidProvider guidProvider)
	{
		public void SetupNewStringGuid(ChatMessage chatMessage)
		{
			guidProvider.ClearCalls().NewStringGuid()
				.ReturnsResponse(chatMessage.Id.MessageId);
		}
	}

	extension(IDateTimeProvider dateTimeProvider)
	{
		public void SetupGetOffsetUtcNow(ChatMessage chatMessage)
		{
			dateTimeProvider
				.ClearCalls()
				.GetOffsetUtcNow()
				.ReturnsResponse(chatMessage.CreatedAtUtc);
		}

		public void SetupGetOffsetUtcNow(
			UpdateChatMessageCommand command,
			ChatMessage chatMessage)
		{
			dateTimeProvider
				.ClearCalls()
				.GetOffsetUtcNow()
				.ReturnsResponse(chatMessage.UpdatedAtUtc);
		}
	}

	extension(IChatMessageFactory factory)
	{
		public void SetupCreate(
			AddChatMessageCommand command,
			ChatMessage chatMessage)
		{
			factory
				.ClearCalls()
				.Create(
					command.Id,
					command.Id.ParticipantOneId,
					command.Content)
				.ReturnsResponse(chatMessage.To(command));
		}
	}

	extension(IChatCommandRepository repository)
	{
		public void SetupGetByIdAsync(
			AddChatMessageCommand command,
			ChatInclude include,
			Chat chat,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.GetByIdAsync(command.Id, ChatMessageDomainMatcher.IsChatInclude(command, include), cancellationToken)
				.ReturnsTaskResponse(chat);
		}

		public void RemoveGetByIdAsync(
			AddChatMessageCommand command,
			ChatInclude include,
			Chat chat,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.GetByIdAsync(command.Id, ChatMessageDomainMatcher.IsChatInclude(command, include), cancellationToken)
				.ReturnsTaskResponse(null);
		}

		public void SetupExistsByIdAsync(
			UpdateChatMessageCommand command,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.ExistsByIdAsync(command.Id.Id, cancellationToken)
				.ReturnsTaskResponse(true);
		}

		public void SetupExistsByIdAsync(
			DeleteChatMessageCommand command,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.ExistsByIdAsync(command.Id.Id, cancellationToken)
				.ReturnsTaskResponse(true);
		}

		public void RemoveExistsByIdAsync(
			UpdateChatMessageCommand command,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.ExistsByIdAsync(command.Id.Id, cancellationToken)
				.ReturnsTaskResponse(false);
		}

		public void RemoveExistsByIdAsync(
			DeleteChatMessageCommand command,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.ExistsByIdAsync(command.Id.Id, cancellationToken)
				.ReturnsTaskResponse(false);
		}
	}

	extension(IChatMessageCommandRepository repository)
	{
		public void SetupGetByIdAsync(
			UpdateChatMessageCommand command,
			ChatMessageInclude include,
			ChatMessage chatMessage,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.GetByIdAsync(command.Id, ChatMessageDomainMatcher.IsChatMessageInclude(command, include), cancellationToken)
				.ReturnsTaskResponse(chatMessage);
		}

		public void SetupGetByIdAsync(
			DeleteChatMessageCommand command,
			ChatMessageInclude include,
			ChatMessage chatMessage,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.GetByIdAsync(command.Id, ChatMessageDomainMatcher.IsChatMessageInclude(command, include), cancellationToken)
				.ReturnsTaskResponse(chatMessage);
		}

		public void RemoveGetByIdAsync(
			UpdateChatMessageCommand command,
			ChatMessageInclude include,
			ChatMessage chatMessage,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.GetByIdAsync(command.Id, ChatMessageDomainMatcher.IsChatMessageInclude(command, include), cancellationToken)
				.ReturnsTaskResponse(null);
		}

		public void RemoveGetByIdAsync(
			DeleteChatMessageCommand command,
			ChatMessageInclude include,
			ChatMessage chatMessage,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.GetByIdAsync(command.Id, ChatMessageDomainMatcher.IsChatMessageInclude(command, include), cancellationToken)
				.ReturnsTaskResponse(null);
		}
	}

	extension(IChatQueryRepository repository)
	{
		public void SetupGetByIdAsync(
			GetAllChatMessagesQuery query,
			Chat chat,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.GetByIdAsync(query.Filter.Id, query.CurrentUser, cancellationToken)
				.ReturnsTaskResponse(chat.ToResponse(query));
		}

		public void RemoveGetByIdAsync(
			GetAllChatMessagesQuery query,
			Chat chat,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.GetByIdAsync(query.Filter.Id, query.CurrentUser, cancellationToken)
				.ReturnsTaskResponse(null);
		}

		public void SetupExistsByIdAsync(
			GetChatMessageByIdQuery query,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.ExistsByIdAsync(query.Id.Id, cancellationToken)
				.ReturnsTaskResponse(true);
		}

		public void RemoveExistsByIdAsync(
			GetChatMessageByIdQuery query,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.ExistsByIdAsync(query.Id.Id, cancellationToken)
				.ReturnsTaskResponse(false);
		}
	}

	extension(IChatMessageQueryRepository repository)
	{
		public void SetupGetAllAsync(
			GetAllChatMessagesQuery query,
			ICollection<ChatMessage> chatMessages,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.GetAllAsync(query.Filter, query.CurrentUser, query.Sorting, query.Pagination, cancellationToken)
				.ReturnsTaskResponse(chatMessages.ToResponse(query));
		}

		public void SetupGetTotalCountAsync(
			GetAllChatMessagesQuery query,
			ICollection<ChatMessage> chatMessages,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.GetTotalCountAsync(query.Filter, cancellationToken)
				.ReturnsTaskResponse(chatMessages.ToTotalCountResponse(query));
		}

		public void SetupGetByIdAsync(
			GetChatMessageByIdQuery query,
			ChatMessage chatMessage,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.GetByIdAsync(query.Id, query.CurrentUser, cancellationToken)
				.ReturnsTaskResponse(chatMessage.ToResponse(query));
		}

		public void RemoveGetByIdAsync(
			GetChatMessageByIdQuery query,
			ChatMessage chatMessage,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.GetByIdAsync(query.Id, query.CurrentUser, cancellationToken)
				.ReturnsTaskResponse(null);
		}
	}
}
