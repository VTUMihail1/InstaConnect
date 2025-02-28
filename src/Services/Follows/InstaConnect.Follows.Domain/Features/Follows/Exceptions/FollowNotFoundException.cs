using InstaConnect.Common.Exceptions.Base;

namespace InstaConnect.Follows.Domain.Features.Follows.Exceptions;

public class FollowNotFoundException : NotFoundException
{
    private const string ErrorMessage = "Follow not found";

    public FollowNotFoundException() : base(ErrorMessage)
    {
    }

    public FollowNotFoundException(Exception exception) : base(ErrorMessage, exception)
    {
    }
}
