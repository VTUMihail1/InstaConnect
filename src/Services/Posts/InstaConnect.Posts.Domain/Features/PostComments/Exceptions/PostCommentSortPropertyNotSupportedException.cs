using InstaConnect.Common.Domain.Exceptions;

namespace InstaConnect.Posts.Domain.Features.PostComments.Exceptions;

public class PostCommentSortPropertyNotSupportedException : BadRequestException
{
    public PostCommentSortPropertyNotSupportedException(PostCommentSortProperty sortProperty)
        : base(PostCommentExceptionErrorMessages.GetSortPropertyNotSupportedMessage(sortProperty))
    {
    }

    public PostCommentSortPropertyNotSupportedException(PostCommentSortProperty sortProperty, Exception exception)
        : base(PostCommentExceptionErrorMessages.GetSortPropertyNotSupportedMessage(sortProperty), exception)
    {
    }
}
