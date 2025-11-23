namespace InstaConnect.Posts.Application.Features.PostComments.Commands.Delete;
public class DeletePostCommentCommandRequestValidator : AbstractValidator<DeletePostCommentCommandRequest>
{
    public DeletePostCommentCommandRequestValidator()
    {
        RuleFor(r => r.Id.Id.Id)
            .NotEmptyWithMessage()
            .PostIdMinLengthWithMessage()
            .PostIdMaxLengthWithMessage();

        RuleFor(r => r.Id.CommentId)
            .NotEmptyWithMessage()
            .PostCommentIdMinLengthWithMessage()
            .PostCommentIdMaxLengthWithMessage();

        RuleFor(r => r.UserId.Id)
            .NotEmptyWithMessage()
            .UserIdMinLengthWithMessage()
            .UserIdMaxLengthWithMessage();
    }
}
