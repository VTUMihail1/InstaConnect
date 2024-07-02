using FluentValidation;

namespace InstaConnect.Posts.Business.Write.Commands.PostLikes.AddPostLike;
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
