using InstaConnect.Common.Application.Features.Requests.Abstractions;
using InstaConnect.Identity.Presentation.Tests.Features.UserClaims.Utilities;

namespace InstaConnect.Identity.Presentation.Tests.Features.UserClaims.Assertions;

public static class UserClaimMockAssertions
{
	extension(IApplicationSender sender)
	{
		public async Task ShouldReceiveOneSendAsync(
		GetAllUserClaimsApiRequest request,
		CancellationToken cancellationToken)
		{
			await sender.ShouldHaveReceivedOne().SendAsync(request.IsGetAllUserClaimsQueryRequest(), cancellationToken);
		}

		public async Task ShouldReceiveOneSendAsync(
			AddUserClaimApiRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldHaveReceivedOne().SendAsync(request.IsAddUserClaimCommandRequest(), cancellationToken);
		}

		public async Task ShouldReceiveOneSendAsync(
			DeleteUserClaimApiRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldHaveReceivedOne().SendAsync(request.IsDeleteUserClaimCommandRequest(), cancellationToken);
		}
	}
}
