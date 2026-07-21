using InstaConnect.Identity.Application.Tests.Features.UserClaims.Utilities;
using InstaConnect.Identity.Events.Features.UserClaims;

namespace InstaConnect.Identity.Application.Tests.Features.UserClaims.Assertions;

public static class UserClaimEventAssertions
{
	extension(UserClaimAddedEventRequest r)
	{
		public bool ShouldSatisfy(AddUserClaimCommandRequest request, UserClaim entity)
		{
			return r.Matches(request, entity);
		}
	}

	extension(UserClaimDeletedEventRequest r)
	{
		public bool ShouldSatisfy(DeleteUserClaimCommandRequest request, UserClaim entity)
		{
			return r.Matches(request, entity);
		}
	}
}
