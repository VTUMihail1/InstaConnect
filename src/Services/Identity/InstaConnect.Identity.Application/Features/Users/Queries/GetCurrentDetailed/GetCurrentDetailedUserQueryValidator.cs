﻿namespace InstaConnect.Identity.Application.Features.Users.Queries.GetCurrentDetailed;

public class GetCurrentDetailedUserQueryValidator : AbstractValidator<GetCurrentDetailedUserQuery>
{
    public GetCurrentDetailedUserQueryValidator()
    {
        RuleFor(q => q.CurrentUserId)
            .NotEmpty()
            .MinimumLength(UserConfigurations.IdMinLength)
            .MaximumLength(UserConfigurations.IdMaxLength);

        RuleFor(q => q.Key)
            .NotEmpty();

        RuleFor(q => q.ExpirationSeconds)
            .NotEmpty();
    }
}
