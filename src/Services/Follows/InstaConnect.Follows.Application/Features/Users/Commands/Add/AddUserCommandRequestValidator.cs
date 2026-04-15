namespace InstaConnect.Follows.Application.Features.Users.Commands.Add;

public class AddUserCommandRequestValidator : AbstractValidator<AddUserCommandRequest>
{
    public AddUserCommandRequestValidator()
    {
        RuleFor(r => r.Id)
            .NotEmptyWithMessage()
            .UserIdMinLengthWithMessage()
            .UserIdMaxLengthWithMessage();

        RuleFor(r => r.Name)
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

        RuleFor(r => r.Email)
            .NotEmptyWithMessage()
            .UserEmailMinLengthWithMessage()
            .UserEmailMaxLengthWithMessage();

        RuleFor(r => r.ProfileImageUrl)
            .UserProfileImageUrlMaxLengthWithMessage();

        RuleFor(r => r.CreatedAtUtc)
            .NotEmptyWithMessage();

        RuleFor(r => r.UpdatedAtUtc)
            .NotEmptyWithMessage();
    }
}
