namespace InstaConnect.Identity.Application.Features.UserClaims.Commands.Delete;

public class DeleteUserClaimCommandRequestValidator : AbstractValidator<DeleteUserClaimCommandRequest>
{
    public DeleteUserClaimCommandRequestValidator()
    {
        RuleFor(r => r.Id)
            .NotEmptyWithMessage()
            .UserIdMinLengthWithMessage()
            .UserIdMaxLengthWithMessage();

        RuleFor(r => r.Claim)
            .NotEmptyWithMessage();
    }
}
