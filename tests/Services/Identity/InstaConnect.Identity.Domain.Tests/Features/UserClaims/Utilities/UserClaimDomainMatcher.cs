using InstaConnect.Identity.Events.Features.UserClaims;

namespace InstaConnect.Identity.Domain.Tests.Features.UserClaims.Utilities;

public static class UserClaimMatcher
{
	public static UserClaimInclude IsUserClaimInclude(DeleteUserClaimCommand command, UserClaimInclude include)
	{
		return Matcher.Is<UserClaimInclude>(p => p.Matches(command, include));
	}

	public static UserClaim IsUserClaim(AddUserClaimCommand command)
	{
		return Matcher.Is<UserClaim>(p => p.Matches(command));
	}

	public static UserClaim IsUserClaim(DeleteUserClaimCommand command)
	{
		return Matcher.Is<UserClaim>(p => p.Matches(command));
	}

	public static UserClaimAddedEventRequest IsUserClaimAddedEventRequest(AddUserClaimCommand command, UserClaim userClaim)
	{
		return Matcher.Is<UserClaimAddedEventRequest>(p => p.Matches(command, userClaim));
	}

	public static UserClaimDeletedEventRequest IsUserClaimDeletedEventRequest(DeleteUserClaimCommand command, UserClaim userClaim)
	{
		return Matcher.Is<UserClaimDeletedEventRequest>(p => p.Matches(command, userClaim));
	}
}
