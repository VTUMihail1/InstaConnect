using FluentValidation;
using InstaConnect.Messages.Business.Utilities;
using InstaConnect.Shared.Business.Models.Filters;

namespace InstaConnect.Messages.Business.Queries.Messages.GetAllFilteredMessages;

public class CollectionModelValidator : AbstractValidator<CollectionModel>
{
    public CollectionModelValidator()
    {
        RuleFor(q => q.SortPropertyName)
            .NotEmpty()
            .MinimumLength(SharedBusinessConfigurations.SORT_PROPERTY_NAME_MIN_LENGTH)
            .MaximumLength(SharedBusinessConfigurations.SORT_PROPERTY_NAME_MAX_LENGTH);

        RuleFor(q => q.Page)
            .LessThanOrEqualTo(SharedBusinessConfigurations.PAGE_MAX_VALUE)
            .GreaterThanOrEqualTo(SharedBusinessConfigurations.PAGE_MIN_VALUE);

        RuleFor(q => q.PageSize)
            .LessThanOrEqualTo(SharedBusinessConfigurations.PAGE_SIZE_MAX_VALUE)
            .GreaterThanOrEqualTo(SharedBusinessConfigurations.PAGE_SIZE_MIN_VALUE);
    }
}
