using InstaConnect.Follows.Tests.Features.Follows.Assertions;
using InstaConnect.Follows.Tests.Features.Users.Assertions;

namespace InstaConnect.Follows.Domain.Tests.Features.Follows.Assertions;

public static class FollowExceptionAssertions
{
	extension(IFollowCommandService service)
	{
		public async Task ShouldThrowFollowerNotFoundExceptionAsync(
			AddFollowCommand request,
			CancellationToken cancellationToken)
		{
			var func = () => service.AddAsync(request, cancellationToken);

			await func.ShouldThrowUserNotFoundExceptionAsync(
				r => r.FollowerId,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowFollowingNotFoundExceptionAsync(
			AddFollowCommand request,
			CancellationToken cancellationToken)
		{
			var func = () => service.AddAsync(request, cancellationToken);

			await func.ShouldThrowUserNotFoundExceptionAsync(
				r => r.FollowingId,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowFollowAlreadyExistsExceptionAsync(
			AddFollowCommand request,
			CancellationToken cancellationToken)
		{
			var func = () => service.AddAsync(request, cancellationToken);

			await func.ShouldThrowFollowAlreadyExistsExceptionAsync(
				r => r.FollowerId.Id,
				r => r.FollowingId.Id,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowFollowNotFoundExceptionAsync(
			DeleteFollowCommand request,
			CancellationToken cancellationToken)
		{
			var func = () => service.DeleteAsync(request, cancellationToken);

			await func.ShouldThrowFollowNotFoundExceptionAsync(
				r => r.Id,
				request,
				cancellationToken);
		}
	}

	extension(IFollowQueryService service)
	{
		public async Task ShouldThrowFollowerNotFoundExceptionAsync(
			GetAllFollowsQuery request,
			CancellationToken cancellationToken)
		{
			var func = () => service.GetAllAsync(request, cancellationToken);

			await func.ShouldThrowUserNotFoundExceptionAsync(
				r => r.Filter.FollowerId,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowFollowingNotFoundExceptionAsync(
			GetAllFollowsForFollowingQuery request,
			CancellationToken cancellationToken)
		{
			var func = () => service.GetAllForFollowingAsync(request, cancellationToken);

			await func.ShouldThrowUserNotFoundExceptionAsync(
				r => r.Filter.FollowingId,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowFollowNotFoundExceptionAsync(
			GetFollowByIdQuery request,
			CancellationToken cancellationToken)
		{
			var func = () => service.GetByIdAsync(request, cancellationToken);

			await func.ShouldThrowFollowNotFoundExceptionAsync(
				r => r.Id,
				request,
				cancellationToken);
		}
	}
}
