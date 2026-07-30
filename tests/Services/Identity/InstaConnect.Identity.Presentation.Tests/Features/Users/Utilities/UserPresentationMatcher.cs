namespace InstaConnect.Identity.Presentation.Tests.Features.Users.Utilities;

public static class UserMatcher
{
	public static GetAllUsersQueryRequest IsGetAllUsersQueryRequest(GetAllUsersApiRequest request)
	{
		return Matcher.Is<GetAllUsersQueryRequest>(p => p.Matches(request));
	}

	public static GetUserByIdQueryRequest IsGetUserByIdQueryRequest(GetUserByIdApiRequest request)
	{
		return Matcher.Is<GetUserByIdQueryRequest>(p => p.Matches(request));
	}

	public static GetCurrentUserByIdQueryRequest IsGetCurrentUserByIdQueryRequest(GetCurrentUserByIdApiRequest request)
	{
		return Matcher.Is<GetCurrentUserByIdQueryRequest>(p => p.Matches(request));
	}

	public static GetUserDetailsByIdQueryRequest IsGetUserDetailsByIdQueryRequest(GetUserDetailsByIdApiRequest request)
	{
		return Matcher.Is<GetUserDetailsByIdQueryRequest>(p => p.Matches(request));
	}

	public static GetCurrentUserDetailsByIdQueryRequest IsGetCurrentUserDetailsByIdQueryRequest(GetCurrentUserDetailsByIdApiRequest request)
	{
		return Matcher.Is<GetCurrentUserDetailsByIdQueryRequest>(p => p.Matches(request));
	}

	public static AddUserCommandRequest IsAddUserCommandRequest(AddUserApiRequest request)
	{
		return Matcher.Is<AddUserCommandRequest>(p => p.Matches(request));
	}

	public static UpdateCurrentUserCommandRequest IsUpdateCurrentUserCommandRequest(UpdateCurrentUserApiRequest request)
	{
		return Matcher.Is<UpdateCurrentUserCommandRequest>(p => p.Matches(request));
	}

	public static DeleteUserCommandRequest IsDeleteUserCommandRequest(DeleteUserApiRequest request)
	{
		return Matcher.Is<DeleteUserCommandRequest>(p => p.Matches(request));
	}

	public static DeleteCurrentUserCommandRequest IsDeleteCurrentUserCommandRequest(DeleteCurrentUserApiRequest request)
	{
		return Matcher.Is<DeleteCurrentUserCommandRequest>(p => p.Matches(request));
	}
}
