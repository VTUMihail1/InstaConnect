using InstaConnect.PostCommentLikes.Common.Features.PostCommentLikes.Utilities;

namespace InstaConnect.Common.Exceptions.Users;

public class PostCommentLikeForbiddenException : ForbiddenException
{
    public PostCommentLikeForbiddenException(
        string id, 
        string commentId, 
        string commentLikeId,
        string userId)
        : base(PostCommentLikeExceptionErrorMessages.GetForbiddenMessage(
            id, 
            commentId, 
            commentLikeId, 
            userId))
    {
    }

    public PostCommentLikeForbiddenException(
        string id,
        string commentId,
        string commentLikeId,
        string userId, 
        Exception exception)
        : base(PostCommentLikeExceptionErrorMessages.GetForbiddenMessage(
            id,
            commentId,
            commentLikeId,
            userId), exception)
    {
    }
}
