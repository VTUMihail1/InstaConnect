using InstaConnect.Shared.Common.Exceptions.Base;

namespace InstaConnect.Shared.Common.Exceptions.Follow;

public class FollowNotFoundException : NotFoundException
{
    private const string ERROR_MESSAGE = "Follow not found";

    public FollowNotFoundException() : base(ERROR_MESSAGE)
    {
    }

    public FollowNotFoundException(Exception exception) : base(ERROR_MESSAGE, exception)
    {
    }
}
