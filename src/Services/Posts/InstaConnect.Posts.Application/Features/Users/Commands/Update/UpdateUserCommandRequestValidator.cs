namespace InstaConnect.Posts.Application.Features.Users.Commands.Update;
public class UpdateUserCommandRequestValidator : AbstractValidator<UpdateUserCommandRequest>
{
    public UpdateUserCommandRequestValidator()
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
