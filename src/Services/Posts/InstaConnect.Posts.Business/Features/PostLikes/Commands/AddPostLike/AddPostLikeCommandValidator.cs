using FluentValidation;

namespace InstaConnect.Posts.Business.Features.PostLikes.Commands.AddPostLike;
public class AddPostLikeCommandValidator : AbstractValidator<AddPostLikeCommand>
{
    public AddPostLikeCommandValidator()
    {
        RuleFor(c => c.CurrentUserId)
            .NotEmpty();

        RuleFor(c => c.PostId)
            .NotEmpty();
    }
}
