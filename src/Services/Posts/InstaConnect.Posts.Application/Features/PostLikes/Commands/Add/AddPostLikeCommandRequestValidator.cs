namespace InstaConnect.Posts.Application.Features.PostLikes.Commands.Add;
public class AddPostLikeCommandRequestValidator : AbstractValidator<AddPostLikeCommandRequest>
{
    public AddPostLikeCommandRequestValidator()
    {
        RuleFor(c => c.CurrentUserId)
            .NotEmpty()
            .MinimumLength(UserConfigurations.IdMinLength)
            .MaximumLength(UserConfigurations.IdMaxLength);

        RuleFor(c => c.PostId)
            .NotEmpty()
            .MinimumLength(PostConfigurations.IdMinLength)
            .MaximumLength(PostConfigurations.IdMaxLength);
    }
}
