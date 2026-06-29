using InstaConnect.Posts.Domain.Features.Users.Models.Responses;

namespace InstaConnect.Posts.Domain.Tests.Features.Users.Utilities;

public static class UserMapper
{
	extension(User user)
	{
		internal UserId ToIdResponse(
)
		{
			return user.Id;
		}

		internal UserResponse ToFullResponse()
		{
			return new(user.Id,
					   user.FirstName,
					   user.LastName,
					   user.Email,
					   user.Name,
					   user.ProfileImage,
					   user.CreatedAtUtc,
					   user.UpdatedAtUtc);
		}

		public User ToFull(AddUserCommand command)
		{
			return new(command.Id,
					   command.FirstName,
					   command.LastName,
					   command.Email,
					   command.Name,
					   command.ProfileImage,
					   command.CreatedAtUtc,
					   command.UpdatedAtUtc);
		}
	}
}
