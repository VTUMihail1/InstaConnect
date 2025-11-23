namespace InstaConnect.Posts.Application.Features.PostCommentLikes.Commands.Delete;
public class DeletePostCommentLikeCommandRequestValidator : AbstractValidator<DeletePostCommentLikeCommandRequest>
{
    public DeletePostCommentLikeCommandRequestValidator()
    {
        RuleFor(r => r.Id.CommentId.Id.Id)
            .NotEmptyWithMessage()
            .PostIdMinLengthWithMessage()
            .PostIdMaxLengthWithMessage();

        RuleFor(r => r.Id.CommentId.CommentId)
            .NotEmptyWithMessage()
            .PostCommentIdMinLengthWithMessage()
            .PostCommentIdMaxLengthWithMessage();

        RuleFor(r => r.Id.UserId.Id)
            .NotEmptyWithMessage()
            .UserIdMinLengthWithMessage()
            .UserIdMaxLengthWithMessage();
    }
}
