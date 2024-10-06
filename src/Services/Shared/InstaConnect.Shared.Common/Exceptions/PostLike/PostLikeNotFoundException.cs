using InstaConnect.Shared.Common.Exceptions.Base;

namespace InstaConnect.Shared.Common.Exceptions.PostLike;

public class PostLikeNotFoundException : NotFoundException
{
    private const string ERROR_MESSAGE = "Post like not found";

    public PostLikeNotFoundException() : base(ERROR_MESSAGE)
    {
    }

    public PostLikeNotFoundException(Exception exception) : base(ERROR_MESSAGE, exception)
    {
    }
}
