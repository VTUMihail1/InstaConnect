using FluentValidation;
using InstaConnect.Messages.Common.Features.Messages.Utilities;

namespace InstaConnect.Messages.Application.Features.Messages.Queries.GetMessageById;

public class GetMessageByIdQueryValidator : AbstractValidator<GetMessageByIdQuery>
{
    public GetMessageByIdQueryValidator()
    {
        RuleFor(q => q.Id)
            .NotEmpty()
            .MinimumLength(MessageConfigurations.IdMinLength)
            .MaximumLength(MessageConfigurations.IdMaxLength);

        RuleFor(q => q.CurrentUserId)
            .NotEmpty()
            .MinimumLength(MessageConfigurations.CURRENT_USER_ID_MIN_LENGTH)
            .MaximumLength(MessageConfigurations.CURRENT_USER_ID_MAX_LENGTH);
    }
}
