namespace InstaConnect.Posts.Application.Features.PostLikes.Commands.Delete;

public class DeletePostLikeCommandValidator : AbstractValidator<DeletePostLikeCommand>
{
    public DeletePostLikeCommandValidator()
    {
        RuleFor(c => c.Id)
            .NotEmpty()
            .MinimumLength(PostLikeBusinessConfigurations.IdMinLength)
            .MaximumLength(PostLikeBusinessConfigurations.IdMaxLength);

        RuleFor(c => c.CurrentUserId)
            .NotEmpty()
            .MinimumLength(UserConfigurations.IdMinLength)
            .MaximumLength(UserConfigurations.IdMaxLength);
    }
}
