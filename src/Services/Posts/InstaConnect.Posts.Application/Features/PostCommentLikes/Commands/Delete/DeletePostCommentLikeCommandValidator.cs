using FluentValidation;

using InstaConnect.Posts.Common.Features.PostCommentLikes.Utilities;
using InstaConnect.Posts.Common.Features.Users.Utilities;

namespace InstaConnect.Posts.Application.Features.PostCommentLikes.Commands.Delete;
public class DeletePostCommentLikeCommandValidator : AbstractValidator<DeletePostCommentLikeCommand>
{
    public DeletePostCommentLikeCommandValidator()
    {
        RuleFor(c => c.Id)
            .NotEmpty()
            .MinimumLength(PostCommentLikeConfigurations.IdMinLength)
            .MaximumLength(PostCommentLikeConfigurations.IdMaxLength);

        RuleFor(c => c.CurrentUserId)
            .NotEmpty()
            .MinimumLength(UserConfigurations.IdMinLength)
            .MaximumLength(UserConfigurations.IdMaxLength);
    }
}
