using InstaConnect.Common.Exceptions.Base;

namespace InstaConnect.Follows.Domain.Features.Follows.Exceptions;
public class FollowAlreadyExistsException : BadRequestException
{
    private const string ErrorMessage = "This user has already been followed";

    public FollowAlreadyExistsException() : base(ErrorMessage)
    {
    }

    public FollowAlreadyExistsException(Exception exception) : base(ErrorMessage, exception)
    {
    }
}
