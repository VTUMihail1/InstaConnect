using FluentValidation;

using InstaConnect.Posts.Common.Features.Posts.Utilities;
using InstaConnect.Posts.Common.Features.Users.Utilities;

namespace InstaConnect.Posts.Application.Features.Posts.Commands.Update;
public class UpdatePostCommandValidator : AbstractValidator<UpdatePostCommand>
{
    public UpdatePostCommandValidator()
    {
        RuleFor(c => c.Id)
            .NotEmpty()
            .MinimumLength(PostConfigurations.IdMinLength)
            .MaximumLength(PostConfigurations.IdMaxLength);

        RuleFor(c => c.CurrentUserId)
            .NotEmpty()
            .MinimumLength(UserConfigurations.IdMinLength)
            .MaximumLength(UserConfigurations.IdMaxLength);

        RuleFor(c => c.Title)
            .NotEmpty()
            .MinimumLength(PostConfigurations.TitleMinLength)
            .MaximumLength(PostConfigurations.TitleMaxLength);

        RuleFor(c => c.Content)
            .NotEmpty()
            .MinimumLength(PostConfigurations.ContentMinLength)
            .MaximumLength(PostConfigurations.ContentMaxLength);
    }
}
