using InstaConnect.Common.Domain.Features.ExceptionHandling.Exceptions;

namespace InstaConnect.Follows.Domain.Features.Users.Exceptions;

public class UserNotFoundException : NotFoundException
{
	public UserNotFoundException(UserId id)
		: base(UserExceptionErrorMessages.GetNotFoundMessage(id))
	{
	}
}
