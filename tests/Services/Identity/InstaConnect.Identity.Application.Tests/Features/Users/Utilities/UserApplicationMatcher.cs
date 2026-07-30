namespace InstaConnect.Identity.Application.Tests.Features.Users.Utilities;

public static class UserMatcher
{
	public static GetAllUsersQuery IsGetAllUsersQuery(GetAllUsersQueryRequest request)
	{
		return Matcher.Is<GetAllUsersQuery>(p => p.Matches(request));
	}

	public static GetUserByIdQuery IsGetUserByIdQuery(GetUserByIdQueryRequest request)
	{
		return Matcher.Is<GetUserByIdQuery>(p => p.Matches(request));
	}

	public static GetUserByIdQuery IsGetUserByIdQuery(GetCurrentUserByIdQueryRequest request)
	{
		return Matcher.Is<GetUserByIdQuery>(p => p.Matches(request));
	}

	public static GetUserByIdQuery IsGetUserByIdQuery(GetUserDetailsByIdQueryRequest request)
	{
		return Matcher.Is<GetUserByIdQuery>(p => p.Matches(request));
	}

	public static GetUserByIdQuery IsGetUserByIdQuery(GetCurrentUserDetailsByIdQueryRequest request)
	{
		return Matcher.Is<GetUserByIdQuery>(p => p.Matches(request));
	}

	public static AddUserCommand IsAddUserCommand(AddUserCommandRequest request)
	{
		return Matcher.Is<AddUserCommand>(p => p.Matches(request));
	}

	public static UpdateUserCommand IsUpdateUserCommand(UpdateCurrentUserCommandRequest request)
	{
		return Matcher.Is<UpdateUserCommand>(p => p.Matches(request));
	}

	public static DeleteUserCommand IsDeleteUserCommand(DeleteUserCommandRequest request)
	{
		return Matcher.Is<DeleteUserCommand>(p => p.Matches(request));
	}

	public static DeleteUserCommand IsDeleteUserCommand(DeleteCurrentUserCommandRequest request)
	{
		return Matcher.Is<DeleteUserCommand>(p => p.Matches(request));
	}
}
