﻿namespace InstaConnect.Posts.Application.Features.Posts.Commands.Add;
public class AddPostCommandValidator : AbstractValidator<AddPostCommand>
{
    public AddPostCommandValidator()
    {
        RuleFor(c => c.CurrentUserId)
            .NotEmpty()
            .MinimumLength(UserConfigurations.IdMinLength)
            .MaximumLength(UserConfigurations.IdMaxLength);

        RuleFor(c => c.Title)
            .NotEmpty()
            .MinimumLength(PostConfigurations.TitleMinLength)
            .MaximumLength(PostConfigurations.TitleMaxLength);

        RuleFor(c => c.Content)
            .NotEmpty()
            .MinimumLength(PostConfigurations.ContentMinLength)
            .MaximumLength(PostConfigurations.ContentMaxLength);
    }
}
