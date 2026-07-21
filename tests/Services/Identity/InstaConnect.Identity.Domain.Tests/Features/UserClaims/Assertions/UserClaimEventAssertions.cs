using InstaConnect.Identity.Domain.Tests.Features.UserClaims.Utilities;
using InstaConnect.Identity.Events.Features.UserClaims;

namespace InstaConnect.Identity.Domain.Tests.Features.UserClaims.Assertions;

public static class UserClaimEventAssertions
{
	extension(UserClaimAddedEventRequest r)
	{
		public bool ShouldSatisfy(AddUserClaimCommand command, UserClaim entity)
		{
			return r.Matches(command, entity);
		}
	}

	extension(UserClaimDeletedEventRequest r)
	{
		public bool ShouldSatisfy(DeleteUserClaimCommand command, UserClaim entity)
		{
			return r.Matches(command, entity);
		}
	}
}
