﻿namespace InstaConnect.Follows.Application.Features.Follows.Commands.Delete;
public class DeleteFollowCommandValidator : AbstractValidator<DeleteFollowCommand>
{
    public DeleteFollowCommandValidator()
    {
        RuleFor(q => q.Id)
            .NotEmpty()
            .MinimumLength(FollowConfigurations.IdMinLength)
            .MaximumLength(FollowConfigurations.IdMaxLength);

        RuleFor(c => c.CurrentUserId)
            .NotEmpty()
            .MinimumLength(UserConfigurations.IdMinLength)
            .MaximumLength(UserConfigurations.IdMaxLength);
    }
}
