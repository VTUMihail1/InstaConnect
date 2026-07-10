using InstaConnect.Common.Domain.Features.DateTimes.Abstractions;
using InstaConnect.Common.Domain.Features.Guids.Abstractions;

namespace InstaConnect.Chats.Domain.Tests.Features.ChatMessages.Utilities;

public static class ChatMessageMockSetups
{
	extension(IGuidProvider guidProvider)
	{
		public void SetupNewStringGuid(ChatMessage chatMessage)
		{
			guidProvider.NewStringGuid()
				.ReturnsResponse(chatMessage.Id.MessageId);
		}
	}

	extension(IDateTimeProvider dateTimeProvider)
	{
		public void SetupGetOffsetUtcNow(ChatMessage chatMessage)
		{
			dateTimeProvider.GetOffsetUtcNow()
				.ReturnsResponse(chatMessage.CreatedAtUtc);
		}

		public void SetupGetOffsetUtcNow(
			UpdateChatMessageCommand command,
			ChatMessage chatMessage)
		{
			dateTimeProvider.GetOffsetUtcNow()
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
				.Create(
					command.Id,
					command.Id.ParticipantOneId,
					command.Content)
				.ReturnsResponse(chatMessage.To(command));
		}
	}

	extension(IChatCommandRepository repository)
	{
		public void SetupGetById(
			AddChatMessageCommand command,
			ChatInclude include,
			Chat chat,
			CancellationToken cancellationToken)
		{
			repository
				.GetByIdAsync(command.Id, ChatMessageMatcher.IsChatInclude(command, include), cancellationToken)
				.ReturnsTaskResponse(chat);
		}

		public void RemoveGetById(
			AddChatMessageCommand command,
			ChatInclude include,
			Chat chat,
			CancellationToken cancellationToken)
		{
			repository
				.GetByIdAsync(command.Id, ChatMessageMatcher.IsChatInclude(command, include), cancellationToken)
				.ReturnsTaskResponse(null);
		}

		public void SetupExistsById(
			UpdateChatMessageCommand command,
			CancellationToken cancellationToken)
		{
			repository
				.ExistsByIdAsync(command.Id.Id, cancellationToken)
				.ReturnsTaskResponse(true);
		}

		public void SetupExistsById(
			DeleteChatMessageCommand command,
			CancellationToken cancellationToken)
		{
			repository
				.ExistsByIdAsync(command.Id.Id, cancellationToken)
				.ReturnsTaskResponse(true);
		}

		public void RemoveExistsById(
			UpdateChatMessageCommand command,
			CancellationToken cancellationToken)
		{
			repository
				.ExistsByIdAsync(command.Id.Id, cancellationToken)
				.ReturnsTaskResponse(false);
		}

		public void RemoveExistsById(
			DeleteChatMessageCommand command,
			CancellationToken cancellationToken)
		{
			repository
				.ExistsByIdAsync(command.Id.Id, cancellationToken)
				.ReturnsTaskResponse(false);
		}
	}

	extension(IChatMessageCommandRepository repository)
	{
		public void SetupGetById(
			UpdateChatMessageCommand command,
			ChatMessageInclude include,
			ChatMessage chatMessage,
			CancellationToken cancellationToken)
		{
			repository
				.GetByIdAsync(command.Id, ChatMessageMatcher.IsChatMessageInclude(command, include), cancellationToken)
				.ReturnsTaskResponse(chatMessage);
		}

		public void SetupGetById(
			DeleteChatMessageCommand command,
			ChatMessageInclude include,
			ChatMessage chatMessage,
			CancellationToken cancellationToken)
		{
			repository
				.GetByIdAsync(command.Id, ChatMessageMatcher.IsChatMessageInclude(command, include), cancellationToken)
				.ReturnsTaskResponse(chatMessage);
		}

		public void RemoveGetById(
			UpdateChatMessageCommand command,
			ChatMessageInclude include,
			ChatMessage chatMessage,
			CancellationToken cancellationToken)
		{
			repository
				.GetByIdAsync(command.Id, ChatMessageMatcher.IsChatMessageInclude(command, include), cancellationToken)
				.ReturnsTaskResponse(null);
		}

		public void RemoveGetById(
			DeleteChatMessageCommand command,
			ChatMessageInclude include,
			ChatMessage chatMessage,
			CancellationToken cancellationToken)
		{
			repository
				.GetByIdAsync(command.Id, ChatMessageMatcher.IsChatMessageInclude(command, include), cancellationToken)
				.ReturnsTaskResponse(null);
		}
	}

	extension(IChatQueryRepository repository)
	{
		public void SetupGetById(
			GetAllChatMessagesQuery query,
			Chat chat,
			CancellationToken cancellationToken)
		{
			repository
				.GetByIdAsync(query.Filter.Id, query.CurrentUser, cancellationToken)
				.ReturnsTaskResponse(chat.ToResponse(query));
		}

		public void RemoveGetById(
			GetAllChatMessagesQuery query,
			Chat chat,
			CancellationToken cancellationToken)
		{
			repository
				.GetByIdAsync(query.Filter.Id, query.CurrentUser, cancellationToken)
				.ReturnsTaskResponse(null);
		}

		public void SetupExistsById(
			GetChatMessageByIdQuery query,
			CancellationToken cancellationToken)
		{
			repository
				.ExistsByIdAsync(query.Id.Id, cancellationToken)
				.ReturnsTaskResponse(true);
		}

		public void RemoveExistsById(
			GetChatMessageByIdQuery query,
			CancellationToken cancellationToken)
		{
			repository
				.ExistsByIdAsync(query.Id.Id, cancellationToken)
				.ReturnsTaskResponse(false);
		}
	}

	extension(IChatMessageQueryRepository repository)
	{
		public void SetupGetAllQuery(
			GetAllChatMessagesQuery query,
			ICollection<ChatMessage> chatMessages,
			CancellationToken cancellationToken)
		{
			repository
				.GetAllAsync(query.Filter, query.CurrentUser, query.Sorting, query.Pagination, cancellationToken)
				.ReturnsTaskResponse(chatMessages.ToResponse(query));
		}

		public void SetupGetTotalCount(
			GetAllChatMessagesQuery query,
			ICollection<ChatMessage> chatMessages,
			CancellationToken cancellationToken)
		{
			repository
				.GetTotalCountAsync(query.Filter, cancellationToken)
				.ReturnsTaskResponse(chatMessages.ToTotalCountResponse(query));
		}

		public void SetupGetById(
			GetChatMessageByIdQuery query,
			ChatMessage chatMessage,
			CancellationToken cancellationToken)
		{
			repository
				.GetByIdAsync(query.Id, query.CurrentUser, cancellationToken)
				.ReturnsTaskResponse(chatMessage.ToResponse(query));
		}

		public void RemoveGetById(
			GetChatMessageByIdQuery query,
			ChatMessage chatMessage,
			CancellationToken cancellationToken)
		{
			repository
				.GetByIdAsync(query.Id, query.CurrentUser, cancellationToken)
				.ReturnsTaskResponse(null);
		}
	}
}
