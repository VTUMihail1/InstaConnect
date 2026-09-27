namespace InstaConnect.Identity.Application.Tests.Features.UserClaims.Utilities;

public static class UserClaimApplicationMatcher
{
	extension(GetAllUserClaimsQueryRequest request)
	{
		public GetAllUserClaimsQuery IsGetAllUserClaimsQuery()
		{
			return Matcher.Is<GetAllUserClaimsQuery>(p => p.Matches(request));
		}
	}

	extension(AddUserClaimCommandRequest request)
	{
		public AddUserClaimCommand IsAddUserClaimCommand()
		{
			return Matcher.Is<AddUserClaimCommand>(p => p.Matches(request));
		}
	}

	extension(DeleteUserClaimCommandRequest request)
	{
		public DeleteUserClaimCommand IsDeleteUserClaimCommand()
		{
			return Matcher.Is<DeleteUserClaimCommand>(p => p.Matches(request));
		}
	}
}
