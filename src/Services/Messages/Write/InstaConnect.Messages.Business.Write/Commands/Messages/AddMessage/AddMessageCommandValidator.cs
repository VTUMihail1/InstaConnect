using FluentValidation;

namespace InstaConnect.Messages.Business.Write.Commands.Messages.AddMessage;
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
