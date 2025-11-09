namespace InstaConnect.Follows.Application.Features.Follows.Queries.GetById;

public class GetFollowByIdQueryRequestValidator : AbstractValidator<GetFollowByIdQueryRequest>
{
    public GetFollowByIdQueryRequestValidator()
    {
        RuleFor(r => r.FollowerId)
            .NotEmpty()
            .WithMessage(UserErrorMessages.GetIdEmpty())
            .MinimumLength(UserConfigurations.IdMinLength)
            .WithMessage(r => UserErrorMessages.GetIdTooShort(r.FollowerId.Length))
            .MaximumLength(UserConfigurations.IdMaxLength)
            .WithMessage(r => UserErrorMessages.GetIdTooLong(r.FollowerId.Length));

        RuleFor(r => r.FollowingId)
            .NotEmpty()
            .WithMessage(UserErrorMessages.GetIdEmpty())
            .MinimumLength(UserConfigurations.IdMinLength)
            .WithMessage(r => UserErrorMessages.GetIdTooShort(r.FollowingId.Length))
            .MaximumLength(UserConfigurations.IdMaxLength)
            .WithMessage(r => UserErrorMessages.GetIdTooLong(r.FollowerId.Length));
    }
}
