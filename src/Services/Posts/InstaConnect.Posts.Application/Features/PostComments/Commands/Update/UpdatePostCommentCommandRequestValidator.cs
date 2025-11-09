namespace InstaConnect.Posts.Application.Features.PostComments.Commands.Update;
public class UpdatePostCommentCommandRequestValidator : AbstractValidator<UpdatePostCommentCommandRequest>
{
    public UpdatePostCommentCommandRequestValidator()
    {
        RuleFor(c => c.Id)
            .NotEmpty()
            .WithMessage(PostErrorMessages.GetIdEmpty())
            .MinimumLength(PostConfigurations.IdMinLength)
            .WithMessage(r => PostErrorMessages.GetIdTooShort(r.Id.Length))
            .MaximumLength(PostConfigurations.IdMaxLength)
            .WithMessage(r => PostErrorMessages.GetIdTooLong(r.Id.Length));

        RuleFor(c => c.CommentId)
            .NotEmpty()
            .WithMessage(PostCommentErrorMessages.GetIdEmpty())
            .MinimumLength(PostCommentConfigurations.IdMinLength)
            .WithMessage(r => PostCommentErrorMessages.GetIdTooShort(r.CommentId.Length))
            .MaximumLength(PostCommentConfigurations.IdMaxLength)
            .WithMessage(r => PostCommentErrorMessages.GetIdTooLong(r.CommentId.Length));

        RuleFor(r => r.UserId)
            .NotEmpty()
            .WithMessage(UserErrorMessages.GetIdEmpty())
            .MinimumLength(UserConfigurations.IdMinLength)
            .WithMessage(r => UserErrorMessages.GetIdTooShort(r.UserId.Length))
            .MaximumLength(UserConfigurations.IdMaxLength)
            .WithMessage(r => UserErrorMessages.GetIdTooLong(r.UserId.Length));

        RuleFor(c => c.Content)
            .NotEmpty()
            .WithMessage(PostCommentErrorMessages.GetContentEmpty())
            .MinimumLength(PostCommentConfigurations.ContentMinLength)
            .WithMessage(r => PostCommentErrorMessages.GetContentTooShort(r.Content.Length))
            .MaximumLength(PostCommentConfigurations.ContentMaxLength)
            .WithMessage(r => PostCommentErrorMessages.GetContentTooLong(r.Content.Length));
    }
}
