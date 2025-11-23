namespace InstaConnect.Follows.Application.Features.Follows.Commands.Delete;
public class DeleteFollowCommandRequestValidator : AbstractValidator<DeleteFollowCommandRequest>
{
    public DeleteFollowCommandRequestValidator()
    {
        RuleFor(r => r.Id.FollowerId.Id)
            .NotEmptyWithMessage()
            .UserIdMinLengthWithMessage()
            .UserIdMaxLengthWithMessage();

        RuleFor(r => r.Id.FollowingId.Id)
            .NotEmptyWithMessage()
            .UserIdMinLengthWithMessage()
            .UserIdMaxLengthWithMessage();
    }
}
