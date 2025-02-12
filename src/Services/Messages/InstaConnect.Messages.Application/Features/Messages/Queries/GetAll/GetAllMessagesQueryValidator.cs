using FluentValidation;
using InstaConnect.Messages.Common.Features.Users.Utilities;
using InstaConnect.Messages.Domain.Features.Messages.Models.Entities;
using InstaConnect.Shared.Application.Abstractions;
using InstaConnect.Shared.Application.Validators;

namespace InstaConnect.Messages.Application.Features.Messages.Queries.GetAll;

public class GetAllMessagesQueryValidator : AbstractValidator<GetAllMessagesQuery>
{
    public GetAllMessagesQueryValidator(IEntityPropertyValidator entityPropertyValidator)
    {
        Include(new CollectionModelValidator());

        RuleFor(q => q.CurrentUserId)
            .NotEmpty()
            .MinimumLength(UserConfigurations.IdMinLength)
            .MaximumLength(UserConfigurations.IdMaxLength);

        RuleFor(q => q.ReceiverId)
            .MinimumLength(UserConfigurations.IdMinLength)
            .MaximumLength(UserConfigurations.IdMaxLength)
            .When(q => !string.IsNullOrEmpty(q.ReceiverId));

        RuleFor(q => q.ReceiverName)
            .MinimumLength(UserConfigurations.NameMinLength)
            .MaximumLength(UserConfigurations.NameMaxLength)
            .When(q => !string.IsNullOrEmpty(q.ReceiverName));

        RuleFor(q => q.SortPropertyName)
            .Must(entityPropertyValidator.IsEntityPropertyValid<Message>);
    }
}
