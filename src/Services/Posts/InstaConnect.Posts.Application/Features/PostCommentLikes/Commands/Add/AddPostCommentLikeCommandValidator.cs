using FluentValidation;
using InstaConnect.Posts.Common.Features.PostComments.Utilities;
using InstaConnect.Posts.Common.Features.Users.Utilities;

namespace InstaConnect.Posts.Application.Features.PostCommentLikes.Commands.Add;
public class AddPostCommentLikeCommandValidator : AbstractValidator<AddPostCommentLikeCommand>
{
    public AddPostCommentLikeCommandValidator()
    {
        RuleFor(c => c.CurrentUserId)
            .NotEmpty()
            .MinimumLength(UserConfigurations.IdMinLength)
            .MaximumLength(UserConfigurations.IdMaxLength);

        RuleFor(c => c.PostCommentId)
            .NotEmpty()
            .MinimumLength(PostCommentConfigurations.IdMinLength)
            .MaximumLength(PostCommentConfigurations.IdMaxLength);
    }
}
