using InstaConnect.Identity.Tests.Features.UserClaims.Assertions;
using InstaConnect.Identity.Tests.Features.Users.Assertions;

namespace InstaConnect.Identity.Domain.Tests.Features.UserClaims.Assertions;

public static class UserClaimExceptionAssertions
{
	extension(IUserClaimCommandService service)
	{
		public async Task ShouldThrowUserNotFoundExceptionAsync(
			AddUserClaimCommand request,
			CancellationToken cancellationToken)
		{
			var func = () => service.AddAsync(request, cancellationToken);

			await func.ShouldThrowUserNotFoundExceptionAsync(
				r => r.Id,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowUserNotFoundExceptionAsync(
			DeleteUserClaimCommand request,
			CancellationToken cancellationToken)
		{
			var func = () => service.DeleteAsync(request, cancellationToken);

			await func.ShouldThrowUserNotFoundExceptionAsync(
				r => r.Id.Id,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowUserClaimAlreadyExistsExceptionAsync(
			AddUserClaimCommand request,
			CancellationToken cancellationToken)
		{
			var func = () => service.AddAsync(request, cancellationToken);

			await func.ShouldThrowUserClaimAlreadyExistsExceptionAsync(
				r => r.Id.Id,
				r => r.Claim,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowUserClaimNotFoundExceptionAsync(
			DeleteUserClaimCommand request,
			CancellationToken cancellationToken)
		{
			var func = () => service.DeleteAsync(request, cancellationToken);

			await func.ShouldThrowUserClaimNotFoundExceptionAsync(
				r => r.Id,
				request,
				cancellationToken);
		}
	}

	extension(IUserClaimQueryService service)
	{
		public async Task ShouldThrowUserNotFoundExceptionAsync(
			GetAllUserClaimsQuery request,
			CancellationToken cancellationToken)
		{
			var func = () => service.GetAllAsync(request, cancellationToken);

			await func.ShouldThrowUserNotFoundExceptionAsync(
				r => r.Filter.Id,
				request,
				cancellationToken);
		}
	}
}
