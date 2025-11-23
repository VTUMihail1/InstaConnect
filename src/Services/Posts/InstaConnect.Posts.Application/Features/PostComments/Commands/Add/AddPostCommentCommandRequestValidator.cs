namespace InstaConnect.Posts.Application.Features.PostComments.Commands.Add;
public class AddPostCommentCommandRequestValidator : AbstractValidator<AddPostCommentCommandRequest>
{
    public AddPostCommentCommandRequestValidator()
    {
        RuleFor(r => r.Id.Id)
            .NotEmptyWithMessage()
            .PostIdMinLengthWithMessage()
            .PostIdMaxLengthWithMessage();

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
