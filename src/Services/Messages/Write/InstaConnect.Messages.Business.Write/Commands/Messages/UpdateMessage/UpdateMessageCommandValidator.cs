using FluentValidation;

namespace InstaConnect.Messages.Business.Write.Commands.Messages.UpdateMessage;
public class UpdateMessageCommandValidator : AbstractValidator<UpdateMessageCommand>
{
    public UpdateMessageCommandValidator()
    {
        RuleFor(c => c.Id)
            .NotEmpty();

        RuleFor(c => c.CurrentUserId)
            .NotEmpty();

        RuleFor(c => c.Content)
            .NotEmpty();
    }
}
