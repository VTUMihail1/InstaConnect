using FluentValidation;

namespace InstaConnect.Messages.Read.Business.Queries.Messages.GetAllFilteredMessages;

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
