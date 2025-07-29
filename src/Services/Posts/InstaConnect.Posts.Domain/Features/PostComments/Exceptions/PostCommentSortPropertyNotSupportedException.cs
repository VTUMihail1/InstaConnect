using InstaConnect.Common.Exceptions;
using InstaConnect.PostComments.Common.Features.PostComments.Utilities;
using InstaConnect.PostComments.Domain.Features.PostComments.Models.Requests;

namespace InstaConnect.Common.Infrastructure.Exceptions;

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
