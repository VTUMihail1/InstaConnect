namespace InstaConnect.Identity.Application.Features.RefreshTokens.Commands.Issue;
public class IssueRefreshTokenCommandRequestValidator : AbstractValidator<IssueRefreshTokenCommandRequest>
{
    public IssueRefreshTokenCommandRequestValidator()
    {
        RuleFor(r => r.Name.Value)
            .NotEmptyWithMessage()
            .UserNameMinLengthWithMessage()
            .UserNameMaxLengthWithMessage();

        RuleFor(r => r.Password)
            .NotEmptyWithMessage()
            .UserPasswordMinLengthWithMessage()
            .UserPasswordMaxLengthWithMessage();
    }
}
