namespace InstaConnect.Posts.Application.Features.PostComments.Commands.Update;
public class UpdatePostCommentCommandRequestValidator : AbstractValidator<UpdatePostCommentCommandRequest>
{
    public UpdatePostCommentCommandRequestValidator()
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

        RuleFor(c => c.Content)
            .NotEmpty()
            .PostTitleMinLengthWithMessage()
            .PostTitleMaxLengthWithMessage();
    }
}
