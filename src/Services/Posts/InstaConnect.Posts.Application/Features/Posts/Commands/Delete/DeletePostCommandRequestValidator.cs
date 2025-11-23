namespace InstaConnect.Posts.Application.Features.Posts.Commands.Delete;
public class DeletePostCommandRequestValidator : AbstractValidator<DeletePostCommandRequest>
{
    public DeletePostCommandRequestValidator()
    {
        RuleFor(r => r.Id.Id)
            .NotEmptyWithMessage()
            .PostIdMinLengthWithMessage()
            .PostIdMaxLengthWithMessage();

        RuleFor(r => r.UserId.Id)
            .NotEmptyWithMessage()
            .UserIdMinLengthWithMessage()
            .UserIdMaxLengthWithMessage();
    }
}
