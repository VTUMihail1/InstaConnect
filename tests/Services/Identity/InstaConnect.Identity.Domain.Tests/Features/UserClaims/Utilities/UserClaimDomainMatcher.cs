using InstaConnect.Identity.Events.Features.UserClaims;

namespace InstaConnect.Identity.Domain.Tests.Features.UserClaims.Utilities;

public static class UserClaimDomainMatcher
{
	extension(DeleteUserClaimCommand command)
	{
		public UserClaim IsUserClaim()
		{
			return Matcher.Is<UserClaim>(p => p.Matches(command));
		}

		public UserClaimDeletedEventRequest IsUserClaimDeletedEventRequest(UserClaim userClaim)
		{
			return Matcher.Is<UserClaimDeletedEventRequest>(p => p.Matches(command, userClaim));
		}
	}

	extension(AddUserClaimCommand command)
	{
		public UserClaim IsUserClaim()
		{
			return Matcher.Is<UserClaim>(p => p.Matches(command));
		}

		public UserClaimAddedEventRequest IsUserClaimAddedEventRequest(UserClaim userClaim)
		{
			return Matcher.Is<UserClaimAddedEventRequest>(p => p.Matches(command, userClaim));
		}
	}
}
