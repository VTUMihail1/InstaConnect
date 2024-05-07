using InstaConnect.Shared.Business.Exceptions.Base;

namespace InstaConnect.Shared.Business.Exceptions.PostLike;

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
