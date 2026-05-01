using InstaConnect.Common.Domain.Features.ExceptionHandling.Exceptions;

namespace InstaConnect.Posts.Domain.Features.PostLikes.Exceptions;

public class PostLikesSortTermNotSupportedException : BadRequestException
{
	public PostLikesSortTermNotSupportedException(PostLikesSortTerm sortTerm)
		: base(PostLikeExceptionErrorMessages.GetSortTermNotSupportedMessage(sortTerm))
	{
	}

	public PostLikesSortTermNotSupportedException(PostLikesSortTerm sortTerm, Exception exception)
		: base(PostLikeExceptionErrorMessages.GetSortTermNotSupportedMessage(sortTerm), exception)
	{
	}
}
