using InstaConnect.Common.Exceptions;
using InstaConnect.Posts.Common.Features.Posts.Utilities;
using InstaConnect.Posts.Domain.Features.Posts.Models.Requests;

namespace InstaConnect.Posts.Domain.Features.Posts.Exceptions;

public class PostIncludePropertiesNotSupportedException : BadRequestException
{
    public PostIncludePropertiesNotSupportedException(ICollection<PostIncludeProperty> includeProperties)
        : base(PostExceptionErrorMessages.GetInclidePropertyNotSupportedMessage(includeProperties))
    {
    }

    public PostIncludePropertiesNotSupportedException(ICollection<PostIncludeProperty> includeProperties, Exception exception)
        : base(PostExceptionErrorMessages.GetInclidePropertyNotSupportedMessage(includeProperties), exception)
    {
    }
}
