using InstaConnect.Common.Extensions;
using InstaConnect.PostComments.Common.Features.PostComments.Utilities;
using InstaConnect.PostComments.Domain.Features.Users.Utilities;
using InstaConnect.Posts.Domain.Features.Users.Utilities;

namespace InstaConnect.PostComments.Application.Features.PostComments.Commands.Add;
public class AddPostCommentCommandRequestValidator : AbstractValidator<AddPostCommentCommandRequest>
{
    public AddPostCommentCommandRequestValidator()
    {
        RuleFor(c => c.Id)
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

        RuleFor(c => c.Content)
            .NotEmpty()
            .WithMessage(PostCommentErrorMessages.GetContentEmpty())
            .MinimumLength(PostCommentConfigurations.ContentMinLength)
            .WithMessage(r => PostCommentErrorMessages.GetContentTooShort(r.Content.Length))
            .MaximumLength(PostCommentConfigurations.ContentMaxLength)
            .WithMessage(r => PostCommentErrorMessages.GetContentTooLong(r.Content.Length));
    }
}
