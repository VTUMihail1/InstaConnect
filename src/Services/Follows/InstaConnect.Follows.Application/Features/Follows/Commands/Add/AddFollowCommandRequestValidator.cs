namespace InstaConnect.Follows.Application.Features.Follows.Commands.Add;
public class AddFollowCommandRequestValidator : AbstractValidator<AddFollowCommandRequest>
{
    public AddFollowCommandRequestValidator()
    {
        RuleFor(r => r.FollowerId.Id)
            .NotEmptyWithMessage()
            .UserIdMinLengthWithMessage()
            .UserIdMaxLengthWithMessage();

        RuleFor(r => r.FollowingId.Id)
            .NotEmptyWithMessage()
            .UserIdMinLengthWithMessage()
            .UserIdMaxLengthWithMessage();
    }
}
