using InstaConnect.Common.Domain.Features.DateTimes.Abstractions;

namespace InstaConnect.Chats.Domain.Tests.Features.Chats.Utilities;

public static class ChatMockSetups
{
	extension(IDateTimeProvider dateTimeProvider)
	{
		public void SetupGetOffsetUtcNow(Chat chat)
		{
			dateTimeProvider.ClearCalls().GetOffsetUtcNow()
				.ReturnsResponse(chat.CreatedAtUtc);
		}
	}

	extension(IChatFactory factory)
	{
		public void SetupCreate(
			AddChatCommand command,
			Chat chat)
		{
			factory
				.ClearCalls()
				.Create(
					command.ParticipantOneId,
					command.ParticipantTwoId)
				.ReturnsResponse(chat.To(command));
		}
	}

	extension(IUserCommandRepository repository)
	{
		public void SetupGetParticipantOneByIdAsync(
			AddChatCommand command,
			User user,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.GetByIdAsync(command.ParticipantOneId, cancellationToken)
				.ReturnsTaskResponse(user);
		}

		public void SetupGetParticipantTwoByIdAsync(
			AddChatCommand command,
			User user,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.GetByIdAsync(command.ParticipantTwoId, cancellationToken)
				.ReturnsTaskResponse(user);
		}

		public void RemoveGetParticipantOneByIdAsync(
			AddChatCommand command,
			User user,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.GetByIdAsync(command.ParticipantOneId, cancellationToken)
				.ReturnsTaskResponse(null);
		}

		public void RemoveGetParticipantTwoByIdAsync(
			AddChatCommand command,
			User user,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.GetByIdAsync(command.ParticipantTwoId, cancellationToken)
				.ReturnsTaskResponse(null);
		}
	}

	extension(IChatCommandRepository repository)
	{
		public void RemoveGetByIdAsync(
			AddChatCommand command,
			Chat chat,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.GetByIdAsync(chat.Id, cancellationToken)
				.ReturnsTaskResponse(null);
		}

		public void SetupGetByIdAsync(
			AddChatCommand command,
			Chat chat,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.GetByIdAsync(chat.Id, cancellationToken)
				.ReturnsTaskResponse(chat);
		}
	}

	extension(IUserQueryRepository repository)
	{
		public void SetupGetByIdAsync(
			GetAllChatsQuery query,
			User user,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.GetByIdAsync(query.Filter.ParticipantOneId, query.CurrentUser, cancellationToken)
				.ReturnsTaskResponse(user.ToResponse(query));
		}

		public void RemoveGetByIdAsync(
			GetAllChatsQuery query,
			User user,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.GetByIdAsync(query.Filter.ParticipantOneId, query.CurrentUser, cancellationToken)
				.ReturnsTaskResponse(null);
		}
	}

	extension(IChatQueryRepository repository)
	{
		public void SetupGetAllAsync(
			GetAllChatsQuery query,
			ICollection<Chat> chats,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.GetAllAsync(query.Filter, query.CurrentUser, query.Sorting, query.Pagination, cancellationToken)
				.ReturnsTaskResponse(chats.ToResponse(query));
		}

		public void SetupGetTotalCountAsync(
			GetAllChatsQuery query,
			ICollection<Chat> chats,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.GetTotalCountAsync(query.Filter, cancellationToken)
				.ReturnsTaskResponse(chats.ToTotalCountResponse(query));
		}

		public void SetupGetByIdAsync(
			GetChatByIdQuery query,
			Chat chat,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.GetByIdAsync(query.Id, query.CurrentUser, cancellationToken)
				.ReturnsTaskResponse(chat.ToResponse(query));
		}

		public void RemoveGetByIdAsync(
			GetChatByIdQuery query,
			Chat chat,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.GetByIdAsync(query.Id, query.CurrentUser, cancellationToken)
				.ReturnsTaskResponse(null);
		}
	}
}
