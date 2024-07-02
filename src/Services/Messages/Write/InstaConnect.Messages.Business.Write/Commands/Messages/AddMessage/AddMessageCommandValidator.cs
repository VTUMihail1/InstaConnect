using FluentValidation;
using InstaConnect.Messages.Business.Commands.Messages.AddMessage;

namespace InstaConnect.Follows.Business.Write.Commands.Follows.AddFollow;
public class AddMessageCommandValidator : AbstractValidator<AddMessageCommand>
{
    public AddMessageCommandValidator()
    {
        RuleFor(c => c.CurrentUserId)
            .NotEmpty();

        RuleFor(c => c.ReceiverId)
            .NotEmpty();

        RuleFor(c => c.Content)
            .NotEmpty();
    }
}
