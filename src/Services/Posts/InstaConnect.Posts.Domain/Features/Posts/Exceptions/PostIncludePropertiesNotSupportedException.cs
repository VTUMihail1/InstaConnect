using InstaConnect.Common.Domain.Exceptions;

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
