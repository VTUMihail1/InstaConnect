using InstaConnect.Follows.Application.Features.Users.Abstractions;
using InstaConnect.Follows.Presentation.Features.Users.Abstractions;
using InstaConnect.Follows.Presentation.Features.Users.Models.Responses;

namespace InstaConnect.Follows.Presentation.Tests.Features.Users.Utilities;

public static class UserEquals
{
	extension(User user)
	{
		public bool Matches(UserAddedEventRequest request)
		{
			return user.Matches(request.User);
		}

		public bool Matches(UserUpdatedEventRequest request)
		{
			return user.Matches(request.User);
		}

		public bool Matches(User u)
		{
			return user.Id.Matches(u.Id.Id) &&
				   user.Email.Matches(u.Email.Value) &&
				   user.FirstName == u.FirstName &&
				   user.LastName == u.LastName &&
				   user.Name.Matches(u.Name.Value) &&
				   user.ProfileImage.Matches(u.ProfileImage?.Url) &&
				   user.CreatedAtUtc == u.CreatedAtUtc &&
				   user.UpdatedAtUtc == u.UpdatedAtUtc;
		}
	}

	extension(AddUserCommandRequest command)
	{
		public bool Matches(UserAddedEventRequest request)
		{
			return command.Id == request.User.Id &&
				   command.Email == request.User.Email &&
				   command.Name == request.User.Name &&
				   command.FirstName == request.User.FirstName &&
				   command.LastName == request.User.LastName &&
				   command.ProfileImageUrl == request.User.ProfileImageUrl;
		}
	}

	extension(UpdateUserCommandRequest command)
	{
		public bool Matches(UserUpdatedEventRequest request)
		{
			return command.Id == request.User.Id &&
				   command.Email == request.User.Email &&
				   command.Name == request.User.Name &&
				   command.FirstName == request.User.FirstName &&
				   command.LastName == request.User.LastName &&
				   command.ProfileImageUrl == request.User.ProfileImageUrl;
		}
	}

	extension(DeleteUserCommandRequest command)
	{
		public bool Matches(UserDeletedEventRequest request)
		{
			return command.Id == request.User.Id;
		}
	}

	extension(UserApiResponse? response)
	{
		public bool MatchesFull(User? user)
		{
			return response != null &&
				   user != null &&
				   user.Id.Matches(response.Id) &&
				   user.FirstName == response.FirstName &&
				   user.LastName == response.LastName &&
				   user.Name.Matches(response.Name) &&
				   user.ProfileImage.Matches(response.ProfileImageUrl) &&
				   user.CreatedAtUtc == response.CreatedAtUtc &&
				   user.UpdatedAtUtc == response.UpdatedAtUtc;
		}
	}

	extension<TQueryRequest>(TQueryRequest query) where TQueryRequest : ICurrentUserableQueryRequest
	{
		public bool MatchesCurrentUserable<TApiRequest>(
		TApiRequest request)
		where TApiRequest : ICurrentUserableApiRequest
		{
			return query.CurrentUserId == request.CurrentUserId;
		}
	}
}
