using InstaConnect.Chats.Domain.Features.Users.Models.Responses;

namespace InstaConnect.Chats.Application.Tests.Features.Users.Utilities;

public static class UserMapper
{
	extension(User user)
	{
		internal UserId ToIdResponse(
)
		{
			return user.Id;
		}

		public UserResponse ToFullResponse()
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

		public UserId ToResponse(
			AddUserCommandRequest request)
		{
			return user.ToIdResponse();
		}

		public UserId ToResponse(
			UpdateUserCommandRequest request)
		{
			return user.ToIdResponse();
		}
	}
}
