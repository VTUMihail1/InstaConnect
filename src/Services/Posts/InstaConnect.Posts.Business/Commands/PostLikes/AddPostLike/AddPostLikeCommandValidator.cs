using FluentValidation;

namespace InstaConnect.Posts.Write.Business.Commands.PostLikes.AddPostLike;
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
