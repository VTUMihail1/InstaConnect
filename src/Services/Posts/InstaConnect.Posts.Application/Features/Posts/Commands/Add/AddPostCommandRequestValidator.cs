namespace InstaConnect.Posts.Application.Features.Posts.Commands.Add;
public class AddPostCommandRequestValidator : AbstractValidator<AddPostCommandRequest>
{
    public AddPostCommandRequestValidator()
    {
        RuleFor(r => r.UserId.Id)
            .NotEmptyWithMessage()
            .UserIdMinLengthWithMessage()
            .UserIdMaxLengthWithMessage();

        RuleFor(r => r.Title)
            .NotEmptyWithMessage()
            .PostTitleMinLengthWithMessage()
            .PostTitleMaxLengthWithMessage();

        RuleFor(r => r.Content)
            .NotEmptyWithMessage()
            .PostContentMinLengthWithMessage()
            .PostContentMaxLengthWithMessage();
    }
}
