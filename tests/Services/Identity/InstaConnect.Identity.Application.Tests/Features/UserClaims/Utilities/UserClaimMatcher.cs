namespace InstaConnect.Identity.Application.Tests.Features.UserClaims.Utilities;

public static class UserClaimMatcher
{
	public static GetAllUserClaimsQuery IsGetAllUserClaimsQuery(GetAllUserClaimsQueryRequest request)
	{
		return Matcher.Is<GetAllUserClaimsQuery>(p => p.Matches(request));
	}

	public static AddUserClaimCommand IsAddUserClaimCommand(AddUserClaimCommandRequest request)
	{
		return Matcher.Is<AddUserClaimCommand>(p => p.Matches(request));
	}

	public static DeleteUserClaimCommand IsDeleteUserClaimCommand(DeleteUserClaimCommandRequest request)
	{
		return Matcher.Is<DeleteUserClaimCommand>(p => p.Matches(request));
	}
}
