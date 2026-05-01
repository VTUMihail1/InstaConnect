using InstaConnect.Common.Domain.Features.ExceptionHandling.Exceptions;

namespace InstaConnect.Posts.Domain.Features.Users.Exceptions;

public class UserAlreadyExistsException : BadRequestException
{
	public UserAlreadyExistsException(UserId id)
		: base(UserExceptionErrorMessages.GetAlreadyExistsMessage(id))
	{
	}
}
