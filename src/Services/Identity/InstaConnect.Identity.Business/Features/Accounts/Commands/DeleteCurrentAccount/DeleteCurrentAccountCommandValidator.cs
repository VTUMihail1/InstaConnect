﻿using FluentValidation;
using InstaConnect.Follows.Business.Features.Follows.Utilities;

namespace InstaConnect.Identity.Business.Features.Accounts.Commands.DeleteCurrentAccount;
public class DeleteCurrentAccountCommandValidator : AbstractValidator<DeleteCurrentAccountCommand>
{
    public DeleteCurrentAccountCommandValidator()
    {
        RuleFor(c => c.CurrentUserId)
            .NotEmpty()
            .MinimumLength(AccountBusinessConfigurations.ID_MIN_LENGTH)
            .MaximumLength(AccountBusinessConfigurations.ID_MAX_LENGTH);
    }
}
