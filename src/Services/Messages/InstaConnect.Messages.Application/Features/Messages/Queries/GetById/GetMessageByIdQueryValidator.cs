using FluentValidation;
using InstaConnect.Messages.Common.Features.Messages.Utilities;
using InstaConnect.Messages.Common.Features.Users.Utilities;

namespace InstaConnect.Messages.Application.Features.Messages.Queries.GetById;

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
            .MinimumLength(UserConfigurations.IdMinLength)
            .MaximumLength(UserConfigurations.IdMaxLength);
    }
}
