using FluentValidation;
using InstaConnect.Messages.Read.Business.Utilities;

namespace InstaConnect.Messages.Read.Business.Queries.Messages.GetMessageById;

public class GetMessageByIdQueryValidator : AbstractValidator<GetMessageByIdQuery>
{
    public GetMessageByIdQueryValidator()
    {
        RuleFor(q => q.Id)
            .NotEmpty()
            .MinimumLength(MessageBusinessConfigurations.ID_MIN_LENGTH)
            .MaximumLength(MessageBusinessConfigurations.ID_MAX_LENGTH);

        RuleFor(q => q.CurrentUserId)
            .NotEmpty()
            .MinimumLength(MessageBusinessConfigurations.CURRENT_USER_ID_MIN_LENGTH)
            .MaximumLength(MessageBusinessConfigurations.CURRENT_USER_ID_MAX_LENGTH);
    }
}
