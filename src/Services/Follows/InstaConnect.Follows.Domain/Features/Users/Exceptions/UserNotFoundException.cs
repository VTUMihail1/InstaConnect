using InstaConnect.Common.Domain.Features.Exceptions.Exceptions;

namespace InstaConnect.Follows.Domain.Features.Users.Exceptions;

public class UserNotFoundException : NotFoundException
{
	public UserNotFoundException(UserId id)
		: base(UserExceptionErrorMessages.GetNotFoundMessage(id))
	{
	}
}
