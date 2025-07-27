using InstaConnect.Common.Exceptions;
using InstaConnect.PostLikes.Common.Features.PostLikes.Utilities;
using InstaConnect.PostLikes.Domain.Features.PostLikes.Models.Requests;

namespace InstaConnect.Common.Infrastructure.Exceptions;

public class PostLikeSortPropertyNotSupportedException : BadRequestException
{
    public PostLikeSortPropertyNotSupportedException(PostLikeSortProperty sortProperty)
        : base(PostLikeExceptionErrorMessages.GetSortPropertyNotSupportedMessage(sortProperty))
    {
    }

    public PostLikeSortPropertyNotSupportedException(PostLikeSortProperty sortProperty, Exception exception)
        : base(PostLikeExceptionErrorMessages.GetSortPropertyNotSupportedMessage(sortProperty), exception)
    {
    }
}
