using InstaConnect.Common.Extensions;
using InstaConnect.PostLikes.Common.Features.PostLikes.Utilities;
using InstaConnect.PostLikes.Domain.Features.Users.Utilities;
using InstaConnect.Posts.Domain.Features.Users.Utilities;

namespace InstaConnect.PostLikes.Application.Features.PostLikes.Commands.Add;
public class AddPostLikeCommandRequestValidator : AbstractValidator<AddPostLikeCommandRequest>
{
    public AddPostLikeCommandRequestValidator()
    {
        RuleFor(r => r.Id)
            .NotEmpty()
            .WithMessage(PostErrorMessages.GetIdEmpty())
            .MinimumLength(PostConfigurations.IdMinLength)
            .WithMessage(r => PostErrorMessages.GetIdTooShort(r.Id.Length))
            .MaximumLength(PostConfigurations.IdMaxLength)
            .WithMessage(r => PostErrorMessages.GetIdTooLong(r.Id.Length));

        RuleFor(r => r.UserId)
            .NotEmpty()
            .WithMessage(UserErrorMessages.GetIdEmpty())
            .MinimumLength(UserConfigurations.IdMinLength)
            .WithMessage(r => UserErrorMessages.GetIdTooShort(r.UserId.Length))
            .MaximumLength(UserConfigurations.IdMaxLength)
            .WithMessage(r => UserErrorMessages.GetIdTooLong(r.UserId.Length));
    }
}
