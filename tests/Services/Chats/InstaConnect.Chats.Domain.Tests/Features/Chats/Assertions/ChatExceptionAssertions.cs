using InstaConnect.Chats.Tests.Features.Chats.Assertions;
using InstaConnect.Chats.Tests.Features.Users.Assertions;

namespace InstaConnect.Chats.Domain.Tests.Features.Chats.Assertions;

public static class ChatExceptionAssertions
{
	extension(IChatCommandService service)
	{
		public async Task ShouldThrowParticipantOneNotFoundExceptionAsync(
			AddChatCommand request,
			CancellationToken cancellationToken)
		{
			var func = () => service.AddAsync(request, cancellationToken);

			await func.ShouldThrowUserNotFoundExceptionAsync(
				request,
				r => r.ParticipantOneId,
				cancellationToken);
		}

		public async Task ShouldThrowParticipantTwoNotFoundExceptionAsync(
			AddChatCommand request,
			CancellationToken cancellationToken)
		{
			var func = () => service.AddAsync(request, cancellationToken);

			await func.ShouldThrowUserNotFoundExceptionAsync(
				request,
				r => r.ParticipantTwoId,
				cancellationToken);
		}

		public async Task ShouldThrowChatAlreadyExistsExceptionAsync(
			AddChatCommand request,
			CancellationToken cancellationToken)
		{
			var func = () => service.AddAsync(request, cancellationToken);

			await func.ShouldThrowChatAlreadyExistsExceptionAsync(
				request,
				r => r.ParticipantOneId.Id,
				r => r.ParticipantTwoId.Id,
				cancellationToken);
		}
	}

	extension(IChatQueryService service)
	{
		public async Task ShouldThrowParticipantOneNotFoundExceptionAsync(
			GetAllChatsQuery request,
			CancellationToken cancellationToken)
		{
			var func = () => service.GetAllAsync(request, cancellationToken);

			await func.ShouldThrowUserNotFoundExceptionAsync(
				request,
				r => r.Filter.ParticipantOneId,
				cancellationToken);
		}

		public async Task ShouldThrowChatNotFoundExceptionAsync(
			GetChatByIdQuery request,
			CancellationToken cancellationToken)
		{
			var func = () => service.GetByIdAsync(request, cancellationToken);

			await func.ShouldThrowChatNotFoundExceptionAsync(
				request,
				r => r.Id,
				cancellationToken);
		}
	}
}
