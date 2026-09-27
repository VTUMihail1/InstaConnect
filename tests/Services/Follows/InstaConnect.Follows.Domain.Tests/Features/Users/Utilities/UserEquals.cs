using InstaConnect.Common.Domain.Features.Common.Extensions;
using InstaConnect.Follows.Domain.Features.Users.Models.Responses;
using InstaConnect.Follows.Domain.Tests.Features.Users.Utilities;

namespace InstaConnect.Follows.Domain.Tests.Features.Users.Utilities;

public static class UserEquals
{
	extension(UserId response)
	{
		public bool Matches(
		AddUserCommand command,
		User user)
		{
			return response.Matches(command.Id);
		}

		public bool Matches(
		UpdateUserCommand command,
		User user)
		{
			return response.Matches(command.Id);
		}
	}

	extension(User u)
	{
		public bool Matches(AddUserCommand command)
		{
			return u.Id.Matches(command.Id) &&
				   u.FirstName == command.FirstName &&
				   u.LastName == command.LastName &&
				   u.Name.Matches(command.Name) &&
				   u.Email.Matches(command.Email) &&
				   u.ProfileImage.Matches(command.ProfileImage) &&
				   u.CreatedAtUtc == command.CreatedAtUtc &&
				   u.UpdatedAtUtc == command.UpdatedAtUtc;
		}

		public bool Matches(UpdateUserCommand command)
		{
			return u.Id.Matches(command.Id) &&
				   u.FirstName == command.FirstName &&
				   u.LastName == command.LastName &&
				   u.Name.Matches(command.Name) &&
				   u.Email.Matches(command.Email) &&
				   u.ProfileImage.Matches(command.ProfileImage) &&
				   u.CreatedAtUtc != default &&
				   u.UpdatedAtUtc == command.UpdatedAtUtc;
		}

		public bool Matches(DeleteUserCommand command)
		{
			return u.Id.Matches(command.Id) &&
				   u.Name.Value.IsNotNullOrEmptyOrWhiteSpace() &&
				   u.Email.Value.IsNotNullOrEmptyOrWhiteSpace() &&
				   u.FirstName.IsNotNullOrEmptyOrWhiteSpace() &&
				   u.LastName.IsNotNullOrEmptyOrWhiteSpace() &&
				   (u.ProfileImage == null || u.ProfileImage.Url.IsNotNullOrEmptyOrWhiteSpace()) &&
				   u.CreatedAtUtc != default &&
				   u.UpdatedAtUtc != default;
		}
	}

	extension(UserResponse? response)
	{
		public bool MatchesFull(User? user)
		{
			return response != null &&
				   user != null &&
				   user.Id.Matches(response.Id) &&
				   user.FirstName == response.FirstName &&
				   user.LastName == response.LastName &&
				   user.Name.Matches(response.Name) &&
				   user.Email.Matches(response.Email) &&
				   user.ProfileImage.Matches(response.ProfileImage) &&
				   user.CreatedAtUtc == response.CreatedAtUtc &&
				   user.UpdatedAtUtc == response.UpdatedAtUtc;
		}
	}
}
