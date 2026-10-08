namespace InstaConnect.Identity.Application.Tests.Features.Users.Utilities;

public static class UserApplicationMatcher
{
	extension(GetAllUsersQueryRequest request)
	{
		public GetAllUsersQuery IsGetAllUsersQuery()
		{
			return Matcher.Is<GetAllUsersQuery>(p => p.Matches(request));
		}
	}

	extension(GetUserByIdQueryRequest request)
	{
		public GetUserByIdQuery IsGetUserByIdQuery()
		{
			return Matcher.Is<GetUserByIdQuery>(p => p.Matches(request));
		}
	}

	extension(GetCurrentUserByIdQueryRequest request)
	{
		public GetUserByIdQuery IsGetUserByIdQuery()
		{
			return Matcher.Is<GetUserByIdQuery>(p => p.Matches(request));
		}
	}

	extension(GetUserDetailsByIdQueryRequest request)
	{
		public GetUserByIdQuery IsGetUserByIdQuery()
		{
			return Matcher.Is<GetUserByIdQuery>(p => p.Matches(request));
		}
	}

	extension(GetCurrentUserDetailsByIdQueryRequest request)
	{
		public GetUserByIdQuery IsGetUserByIdQuery()
		{
			return Matcher.Is<GetUserByIdQuery>(p => p.Matches(request));
		}
	}

	extension(AddUserCommandRequest request)
	{
		public AddUserCommand IsAddUserCommand()
		{
			return Matcher.Is<AddUserCommand>(p => p.Matches(request));
		}
	}

	extension(UpdateCurrentUserCommandRequest request)
	{
		public UpdateUserCommand IsUpdateUserCommand()
		{
			return Matcher.Is<UpdateUserCommand>(p => p.Matches(request));
		}
	}

	extension(DeleteUserCommandRequest request)
	{
		public DeleteUserCommand IsDeleteUserCommand()
		{
			return Matcher.Is<DeleteUserCommand>(p => p.Matches(request));
		}
	}

	extension(DeleteCurrentUserCommandRequest request)
	{
		public DeleteUserCommand IsDeleteUserCommand()
		{
			return Matcher.Is<DeleteUserCommand>(p => p.Matches(request));
		}
	}
}
