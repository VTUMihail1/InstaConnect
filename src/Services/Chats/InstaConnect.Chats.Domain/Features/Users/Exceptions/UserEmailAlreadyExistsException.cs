using InstaConnect.Common.Domain.Features.ExceptionHandling.Exceptions;

namespace InstaConnect.Chats.Domain.Features.Users.Exceptions;

public class UserEmailAlreadyExistsException : BadRequestException
{
	public UserEmailAlreadyExistsException(Email email)
		: base(UserExceptionErrorMessages.GetEmailAlreadyExistsMessage(email))
	{
	}
}
