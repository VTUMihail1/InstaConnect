using FluentValidation;

namespace InstaConnect.Posts.Business.Features.Posts.Commands.AddPost;
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
