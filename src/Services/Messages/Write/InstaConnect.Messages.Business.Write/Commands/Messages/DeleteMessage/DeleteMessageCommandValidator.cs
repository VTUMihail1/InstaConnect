using FluentValidation;
using InstaConnect.Messages.Business.Commands.Messages.DeleteMessage;

namespace InstaConnect.Follows.Business.Write.Commands.Follows.AddFollow;

public class DeleteMessageCommandValidator : AbstractValidator<DeleteMessageCommand>
{
    public DeleteMessageCommandValidator()
    {
        RuleFor(c => c.Id)
            .NotEmpty();

        RuleFor(c => c.CurrentUserId)
            .NotEmpty();
    }
}
