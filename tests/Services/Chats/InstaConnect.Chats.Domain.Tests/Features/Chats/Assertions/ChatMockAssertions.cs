using InstaConnect.Chats.Domain.Tests.Features.Chats.Utilities;
using InstaConnect.Common.Events.Features.Common.Abstractions;

namespace InstaConnect.Chats.Domain.Tests.Features.Chats.Assertions;

public static class ChatMockAssertions
{
	extension(IChatFactory factory)
	{
		public void ShouldReceiveOneCreate(
			AddChatCommand command)
		{
			factory.ShouldHaveReceivedOne().Create(
				command.ParticipantOneId,
				command.ParticipantTwoId);
		}
	}

	extension(IUserCommandRepository repository)
	{
		public async Task ShouldReceiveOneGetByParticipantOneIdAsync(
			AddChatCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetByIdAsync(
				command.ParticipantOneId,
				cancellationToken);
		}

		public async Task ShouldReceiveOneGetByParticipantTwoIdAsync(
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
		public async Task ShouldReceiveOneGetByIdAsync(
			AddChatCommand command,
			Chat chat,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetByIdAsync(
				chat.Id,
				cancellationToken);
		}

		public async Task ShouldReceiveOneAddAsync(
			AddChatCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().AddAsync(ChatDomainMatcher.IsChat(command), cancellationToken);
		}
	}

	extension(IUserQueryRepository repository)
	{
		public async Task ShouldReceiveOneGetByIdAsync(
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
		public async Task ShouldReceiveOneGetAllAsync(
			GetAllChatsQuery query,
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
			GetAllChatsQuery query,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetTotalCountAsync(
				query.Filter,
				cancellationToken);
		}

		public async Task ShouldReceiveOneGetByIdAsync(
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
		public async Task ShouldReceiveOnePublishAsync(
			AddChatCommand command,
			Chat chat,
			CancellationToken cancellationToken)
		{
			await eventPublisher.ShouldHaveReceivedOne().PublishAsync(ChatDomainMatcher.IsChatAddedEventRequest(command, chat), cancellationToken);
		}
	}
}
