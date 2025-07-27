namespace InstaConnect.Posts.Application.Features.PostLikes.Commands.Delete;

public class DeletePostLikeCommandRequestValidator : AbstractValidator<DeletePostLikeCommandRequest>
{
    public DeletePostLikeCommandRequestValidator()
    {
        RuleFor(c => c.Id)
            .NotEmpty()
            .MinimumLength(PostLikeConfigurations.IdMinLength)
            .MaximumLength(PostLikeConfigurations.IdMaxLength);

        RuleFor(c => c.CurrentUserId)
            .NotEmpty()
            .MinimumLength(UserConfigurations.IdMinLength)
            .MaximumLength(UserConfigurations.IdMaxLength);
    }
}
