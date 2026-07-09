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
				r => r.ParticipantOneId,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowParticipantTwoNotFoundExceptionAsync(
			AddChatCommand request,
			CancellationToken cancellationToken)
		{
			var func = () => service.AddAsync(request, cancellationToken);

			await func.ShouldThrowUserNotFoundExceptionAsync(
				r => r.ParticipantTwoId,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowChatAlreadyExistsExceptionAsync(
			AddChatCommand request,
			CancellationToken cancellationToken)
		{
			var func = () => service.AddAsync(request, cancellationToken);

			await func.ShouldThrowChatAlreadyExistsExceptionAsync(
				r => r.ParticipantOneId.Id,
				r => r.ParticipantTwoId.Id,
				request,
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
				r => r.Filter.ParticipantOneId,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowChatNotFoundExceptionAsync(
			GetChatByIdQuery request,
			CancellationToken cancellationToken)
		{
			var func = () => service.GetByIdAsync(request, cancellationToken);

			await func.ShouldThrowChatNotFoundExceptionAsync(
				r => r.Id,
				request,
				cancellationToken);
		}
	}
}
