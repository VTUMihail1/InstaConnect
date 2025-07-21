using InstaConnect.Common.Exceptions;
using InstaConnect.Posts.Common.Features.Posts.Utilities;

namespace InstaConnect.Posts.Domain.Features.Posts.Exceptions;

public class PostNotFoundException : NotFoundException
{
    public PostNotFoundException(string id)
        : base(PostExceptionErrorMessages.GetNotFoundMessage(id))
    {
    }

    public PostNotFoundException(string id, Exception exception)
        : base(PostExceptionErrorMessages.GetNotFoundMessage(id), exception)
    {
    }
}
