using InstaConnect.Chats.Domain.Tests.Features.Chats.Utilities;
using InstaConnect.Common.Events.Features.Events.Abstractions;

namespace InstaConnect.Chats.Domain.Tests.Features.Chats.Assertions;

public static class ChatMockAssertions
{
	extension(IChatFactory factory)
	{
		public void ShouldHaveReceivedOneCreate(
			AddChatCommand command)
		{
			factory.ShouldHaveReceivedOne().Create(
				command.ParticipantOneId,
				command.ParticipantTwoId);
		}
	}

	extension(IUserCommandRepository repository)
	{
		public async Task ShouldHaveReceivedOneGetByParticipantOneIdAsync(
			AddChatCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetByIdAsync(
				command.ParticipantOneId,
				cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetByParticipantTwoIdAsync(
			AddChatCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetByIdAsync(
				command.ParticipantTwoId,
				cancellationToken);
		}
	}

	extension(IChatCommandRepository repository)
	{
		public async Task ShouldHaveReceivedOneGetByIdAsync(
			AddChatCommand command,
			Chat chat,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetByIdAsync(
				chat.Id,
				cancellationToken);
		}

		public async Task ShouldHaveReceivedOneAddAsync(
			AddChatCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().AddAsync(command.IsChat(), cancellationToken);
		}
	}

	extension(IUserQueryRepository repository)
	{
		public async Task ShouldHaveReceivedOneGetByIdAsync(
			GetAllChatsQuery query,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetByIdAsync(
				query.Filter.ParticipantOneId,
				query.CurrentUser,
				cancellationToken);
		}
	}

	extension(IChatQueryRepository repository)
	{
		public async Task ShouldHaveReceivedOneGetAllAsync(
			GetAllChatsQuery query,
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
			GetAllChatsQuery query,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetTotalCountAsync(
				query.Filter,
				cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetByIdAsync(
			GetChatByIdQuery query,
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
		public async Task ShouldHaveReceivedOnePublishAsync(
			AddChatCommand command,
			Chat chat,
			CancellationToken cancellationToken)
		{
			await eventPublisher.ShouldHaveReceivedOne().PublishAsync(command.IsChatAddedEventRequest(chat), cancellationToken);
		}
	}
}
