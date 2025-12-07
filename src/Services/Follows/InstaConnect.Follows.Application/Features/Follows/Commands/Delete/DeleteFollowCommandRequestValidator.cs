namespace InstaConnect.Follows.Application.Features.Follows.Commands.Delete;
public class DeleteFollowCommandRequestValidator : AbstractValidator<DeleteFollowCommandRequest>
{
    public DeleteFollowCommandRequestValidator()
    {
        RuleFor(r => r.FollowerId)
            .NotEmptyWithMessage()
            .UserIdMinLengthWithMessage()
            .UserIdMaxLengthWithMessage();

        RuleFor(r => r.FollowingId)
            .NotEmptyWithMessage()
            .UserIdMinLengthWithMessage()
            .UserIdMaxLengthWithMessage();
    }
}
