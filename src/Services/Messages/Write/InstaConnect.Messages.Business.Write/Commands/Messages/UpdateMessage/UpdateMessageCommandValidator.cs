using FluentValidation;
using InstaConnect.Messages.Business.Commands.Messages.AddMessage;
using InstaConnect.Messages.Business.Commands.Messages.UpdateMessage;

namespace InstaConnect.Follows.Business.Write.Commands.Follows.AddFollow;
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
