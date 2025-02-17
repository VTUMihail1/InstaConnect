namespace InstaConnect.Posts.Application.Features.PostComments.Commands.Delete;
public class DeletePostCommentCommandValidator : AbstractValidator<DeletePostCommentCommand>
{
    public DeletePostCommentCommandValidator()
    {
        RuleFor(c => c.Id)
            .NotEmpty()
            .MinimumLength(PostCommentConfigurations.IdMinLength)
            .MaximumLength(PostCommentConfigurations.IdMaxLength);

        RuleFor(c => c.CurrentUserId)
            .NotEmpty()
            .MinimumLength(UserConfigurations.IdMinLength)
            .MaximumLength(UserConfigurations.IdMaxLength);
    }
}
