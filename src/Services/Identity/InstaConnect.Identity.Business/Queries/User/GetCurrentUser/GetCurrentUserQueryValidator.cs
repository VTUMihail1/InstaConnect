﻿using FluentValidation;

namespace InstaConnect.Identity.Business.Queries.User.GetCurrentUser;

public class GetCurrentUserQueryValidator : AbstractValidator<GetCurrentUserQuery>
{
    public GetCurrentUserQueryValidator()
    {
        RuleFor(q => q.CurrentUserId)
            .NotEmpty();

        RuleFor(q => q.Key)
            .NotEmpty();

        RuleFor(q => q.Expiration)
            .NotEmpty();
    }
}
