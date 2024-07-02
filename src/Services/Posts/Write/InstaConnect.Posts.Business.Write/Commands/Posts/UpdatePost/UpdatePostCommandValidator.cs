using FluentValidation;
using InstaConnect.Posts.Business.Commands.PostCommentLikes.DeletePostCommentLike;
using InstaConnect.Posts.Business.Commands.Posts.UpdatePost;

namespace InstaConnect.Follows.Business.Write.Commands.Follows.AddFollow;
public class UpdatePostCommandValidator : AbstractValidator<UpdatePostCommand>
{
    public UpdatePostCommandValidator()
    {
        RuleFor(c => c.Id)
            .NotEmpty();

        RuleFor(c => c.CurrentUserId)
            .NotEmpty();

        RuleFor(c => c.Title)
            .NotEmpty();

        RuleFor(c => c.Content)
            .NotEmpty();
    }
}
