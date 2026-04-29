using InstaConnect.Common.Domain.Features.ExceptionHandling.Exceptions;

namespace InstaConnect.Chats.Domain.Features.Users.Exceptions;

public class UserAlreadyExistsException : BadRequestException
{
	public UserAlreadyExistsException(UserId id)
		: base(UserExceptionErrorMessages.GetAlreadyExistsMessage(id))
	{
	}
}
