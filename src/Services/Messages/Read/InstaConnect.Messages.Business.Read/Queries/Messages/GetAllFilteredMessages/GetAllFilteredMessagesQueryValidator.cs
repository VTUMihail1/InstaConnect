using FluentValidation;
using InstaConnect.Messages.Business.Read.Queries.Messages.GetAllFilteredMessages;

namespace InstaConnect.Identity.Business.Commands.Account.ConfirmAccountEmail;

public class GetAllFilteredMessagesQueryValidator : AbstractValidator<GetAllFilteredMessagesQuery>
{
    public GetAllFilteredMessagesQueryValidator()
    {
        RuleFor(q => q.Offset)
            .NotEmpty()
            .GreaterThanOrEqualTo(default(int));

        RuleFor(q => q.Limit)
            .NotEmpty()
            .GreaterThanOrEqualTo(default(int));

        RuleFor(q => q.SortOrder)
            .NotEmpty()
            .IsInEnum();

        RuleFor(q => q.SortPropertyName)
            .NotEmpty();
    }
}
