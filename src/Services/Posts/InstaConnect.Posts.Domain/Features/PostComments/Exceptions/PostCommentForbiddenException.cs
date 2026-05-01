using InstaConnect.Common.Domain.Features.ExceptionHandling.Exceptions;

namespace InstaConnect.Posts.Domain.Features.PostComments.Exceptions;

public class PostCommentForbiddenException : ForbiddenException
{
	public PostCommentForbiddenException(PostCommentId id, UserId userId)
		: base(PostCommentExceptionErrorMessages.GetForbiddenMessage(id, userId))
	{
	}

	public PostCommentForbiddenException(PostCommentId id, UserId userId, Exception exception)
		: base(PostCommentExceptionErrorMessages.GetForbiddenMessage(id, userId), exception)
	{
	}
}
