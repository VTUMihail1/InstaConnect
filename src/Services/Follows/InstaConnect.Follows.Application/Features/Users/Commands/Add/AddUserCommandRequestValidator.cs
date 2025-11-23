namespace InstaConnect.Follows.Application.Features.Users.Commands.Add;
public class AddUserCommandRequestValidator : AbstractValidator<AddUserCommandRequest>
{
    public AddUserCommandRequestValidator()
    {
        RuleFor(r => r.Id.Id)
            .NotEmptyWithMessage()
            .UserIdMinLengthWithMessage()
            .UserIdMaxLengthWithMessage();

        RuleFor(r => r.Name.Value)
            .NotEmptyWithMessage()
            .UserNameMinLengthWithMessage()
            .UserNameMaxLengthWithMessage();

        RuleFor(r => r.FirstName)
            .NotEmptyWithMessage()
            .UserFirstNameMinLengthWithMessage()
            .UserFirstNameMaxLengthWithMessage();

        RuleFor(r => r.LastName)
            .NotEmptyWithMessage()
            .UserLastNameMinLengthWithMessage()
            .UserLastNameMaxLengthWithMessage();

        RuleFor(r => r.Email.Value)
            .NotEmptyWithMessage()
            .UserEmailMinLengthWithMessage()
            .UserEmailMaxLengthWithMessage();

        RuleFor(r => r.ProfileImage!.Url)
            .UserProfileImageMaxLengthWithMessage();
    }
}
