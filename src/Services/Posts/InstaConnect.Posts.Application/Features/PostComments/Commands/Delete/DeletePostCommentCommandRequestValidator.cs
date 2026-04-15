namespace InstaConnect.Posts.Application.Features.PostComments.Commands.Delete;

public class DeletePostCommentCommandRequestValidator : AbstractValidator<DeletePostCommentCommandRequest>
{
    public DeletePostCommentCommandRequestValidator()
    {
        RuleFor(r => r.Id)
            .NotEmptyWithMessage()
            .PostIdMinLengthWithMessage()
            .PostIdMaxLengthWithMessage();

        RuleFor(r => r.CommentId)
            .NotEmptyWithMessage()
            .PostCommentIdMinLengthWithMessage()
            .PostCommentIdMaxLengthWithMessage();

        RuleFor(r => r.UserId)
            .NotEmptyWithMessage()
            .UserIdMinLengthWithMessage()
            .UserIdMaxLengthWithMessage();
    }
}
