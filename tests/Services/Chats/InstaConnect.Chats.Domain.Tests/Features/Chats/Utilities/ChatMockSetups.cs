using InstaConnect.Common.Domain.Features.DateTimes.Abstractions;

namespace InstaConnect.Chats.Domain.Tests.Features.Chats.Utilities;

public static class ChatMockSetups
{
	extension(IDateTimeProvider dateTimeProvider)
	{
		public void SetupGetOffsetUtcNow(Chat chat)
		{
			dateTimeProvider.GetOffsetUtcNow()
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
				.Create(
					command.ParticipantOneId,
					command.ParticipantTwoId)
				.ReturnsResponse(chat.To(command));
		}
	}

	extension(IUserCommandRepository repository)
	{
		public void SetupGetByParticipantOneId(
			AddChatCommand command,
			User user,
			CancellationToken cancellationToken)
		{
			repository
				.GetByIdAsync(command.ParticipantOneId, cancellationToken)
				.ReturnsTaskResponse(user);
		}

		public void SetupGetByParticipantTwoId(
			AddChatCommand command,
			User user,
			CancellationToken cancellationToken)
		{
			repository
				.GetByIdAsync(command.ParticipantTwoId, cancellationToken)
				.ReturnsTaskResponse(user);
		}

		public void RemoveGetByParticipantOneId(
			AddChatCommand command,
			User user,
			CancellationToken cancellationToken)
		{
			repository
				.GetByIdAsync(command.ParticipantOneId, cancellationToken)
				.ReturnsTaskResponse(null);
		}

		public void RemoveGetByParticipantTwoId(
			AddChatCommand command,
			User user,
			CancellationToken cancellationToken)
		{
			repository
				.GetByIdAsync(command.ParticipantTwoId, cancellationToken)
				.ReturnsTaskResponse(null);
		}
	}

	extension(IChatCommandRepository repository)
	{
		public void SetupGetById(
			Chat chat,
			CancellationToken cancellationToken)
		{
			repository
				.GetByIdAsync(chat.Id, cancellationToken)
				.ReturnsTaskResponse(null);
		}

		public void SetupGetByIdExists(
			Chat chat,
			CancellationToken cancellationToken)
		{
			repository
				.GetByIdAsync(chat.Id, cancellationToken)
				.ReturnsTaskResponse(chat);
		}
	}

	extension(IUserQueryRepository repository)
	{
		public void SetupGetById(
			GetAllChatsQuery query,
			User user,
			CancellationToken cancellationToken)
		{
			repository
				.GetByIdAsync(query.Filter.ParticipantOneId, query.CurrentUser, cancellationToken)
				.ReturnsTaskResponse(user.ToResponse(query));
		}

		public void RemoveGetById(
			GetAllChatsQuery query,
			User user,
			CancellationToken cancellationToken)
		{
			repository
				.GetByIdAsync(query.Filter.ParticipantOneId, query.CurrentUser, cancellationToken)
				.ReturnsTaskResponse(null);
		}
	}

	extension(IChatQueryRepository repository)
	{
		public void SetupGetAllQuery(
			GetAllChatsQuery query,
			ICollection<Chat> chats,
			CancellationToken cancellationToken)
		{
			repository
				.GetAllAsync(query.Filter, query.CurrentUser, query.Sorting, query.Pagination, cancellationToken)
				.ReturnsTaskResponse(chats.ToResponse(query));
		}

		public void SetupGetTotalCount(
			GetAllChatsQuery query,
			ICollection<Chat> chats,
			CancellationToken cancellationToken)
		{
			repository
				.GetTotalCountAsync(query.Filter, cancellationToken)
				.ReturnsTaskResponse(chats.ToTotalCountResponse(query));
		}

		public void SetupGetById(
			GetChatByIdQuery query,
			Chat chat,
			CancellationToken cancellationToken)
		{
			repository
				.GetByIdAsync(query.Id, query.CurrentUser, cancellationToken)
				.ReturnsTaskResponse(chat.ToResponse(query));
		}

		public void RemoveGetById(
			GetChatByIdQuery query,
			Chat chat,
			CancellationToken cancellationToken)
		{
			repository
				.GetByIdAsync(query.Id, query.CurrentUser, cancellationToken)
				.ReturnsTaskResponse(null);
		}
	}
}
