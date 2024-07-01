using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using InstaConnect.Identity.Business.Commands.Account.DeleteAccount;

namespace InstaConnect.Identity.Business.Commands.Account.ConfirmAccountEmail;
public class DeleteCurrentAccountCommandValidator : AbstractValidator<DeleteCurrentAccountCommand>
{
    public DeleteCurrentAccountCommandValidator()
    {
        RuleFor(c => c.CurrentUserId)
            .NotEmpty();
    }
}
