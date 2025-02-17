namespace InstaConnect.Posts.Application.Features.PostComments.Commands.Add;
public class AddPostCommentCommandValidator : AbstractValidator<AddPostCommentCommand>
{
    public AddPostCommentCommandValidator()
    {
        RuleFor(c => c.CurrentUserId)
            .NotEmpty()
            .MinimumLength(UserConfigurations.IdMinLength)
            .MaximumLength(UserConfigurations.IdMaxLength);

        RuleFor(c => c.PostId)
            .NotEmpty()
            .MinimumLength(PostConfigurations.IdMinLength)
            .MaximumLength(PostConfigurations.IdMaxLength);

        RuleFor(c => c.Content)
            .NotEmpty()
            .MinimumLength(PostCommentConfigurations.ContentMinLength)
            .MaximumLength(PostCommentConfigurations.ContentMaxLength);
    }
}
