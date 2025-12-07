namespace InstaConnect.Posts.Application.Features.Posts.Commands.Delete;
public class DeletePostCommandRequestValidator : AbstractValidator<DeletePostCommandRequest>
{
    public DeletePostCommandRequestValidator()
    {
        RuleFor(r => r.Id)
            .NotEmptyWithMessage()
            .PostIdMinLengthWithMessage()
            .PostIdMaxLengthWithMessage();

        RuleFor(r => r.UserId)
            .NotEmptyWithMessage()
            .UserIdMinLengthWithMessage()
            .UserIdMaxLengthWithMessage();
    }
}
