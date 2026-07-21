using InstaConnect.Identity.Events.Features.UserClaims;
using InstaConnect.Identity.Presentation.Tests.Features.UserClaims.Utilities;
using InstaConnect.Identity.Presentation.Tests.Features.Users.Utilities;

namespace InstaConnect.Identity.Presentation.Tests.Features.UserClaims.Assertions;

public static class UserClaimEventAssertions
{
	extension(UserClaimAddedEventRequest r)
	{
		public bool ShouldSatisfy(AddUserClaimApiRequest request, UserClaim entity)
		{
			return r.Matches(request, entity);
		}
	}

	extension(UserClaimDeletedEventRequest r)
	{
		public bool ShouldSatisfy(DeleteUserClaimApiRequest request, UserClaim entity)
		{
			return r.Matches(request, entity);
		}
	}
}
