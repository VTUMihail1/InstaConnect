namespace InstaConnect.Identity.Application.Features.EmailConfirmationTokens.Commands.Add;

public class AddEmailConfirmationTokenCommandRequestValidator : AbstractValidator<AddEmailConfirmationTokenCommandRequest>
{
    public AddEmailConfirmationTokenCommandRequestValidator()
    {
        RuleFor(r => r.Name)
            .NotEmptyWithMessage()
            .UserNameMinLengthWithMessage()
            .UserNameMaxLengthWithMessage();
    }
}
