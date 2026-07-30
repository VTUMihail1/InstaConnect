namespace InstaConnect.Identity.Presentation.Tests.Features.UserClaims.Utilities;

public static class UserClaimMatcher
{
	public static GetAllUserClaimsQueryRequest IsGetAllUserClaimsQueryRequest(GetAllUserClaimsApiRequest request)
	{
		return Matcher.Is<GetAllUserClaimsQueryRequest>(p => p.Matches(request));
	}

	public static AddUserClaimCommandRequest IsAddUserClaimCommandRequest(AddUserClaimApiRequest request)
	{
		return Matcher.Is<AddUserClaimCommandRequest>(p => p.Matches(request));
	}

	public static DeleteUserClaimCommandRequest IsDeleteUserClaimCommandRequest(DeleteUserClaimApiRequest request)
	{
		return Matcher.Is<DeleteUserClaimCommandRequest>(p => p.Matches(request));
	}
}
