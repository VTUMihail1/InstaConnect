namespace InstaConnect.Posts.Application.Features.Posts.Commands.Update;
public class UpdatePostCommandRequestValidator : AbstractValidator<UpdatePostCommandRequest>
{
    public UpdatePostCommandRequestValidator()
    {
        RuleFor(r => r.Id.Id)
            .NotEmptyWithMessage()
            .PostIdMinLengthWithMessage()
            .PostIdMaxLengthWithMessage();

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
