using FluentValidation;

namespace InstaConnect.Posts.Business.Write.Commands.Posts.AddPost;
public class AddPostCommandValidator : AbstractValidator<AddPostCommand>
{
    public AddPostCommandValidator()
    {
        RuleFor(c => c.CurrentUserId)
            .NotEmpty();

        RuleFor(c => c.Title)
            .NotEmpty();

        RuleFor(c => c.Content)
            .NotEmpty();
    }
}
