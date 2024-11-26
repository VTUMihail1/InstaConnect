using FluentValidation;
using InstaConnect.Shared.Application.Models.Filters;
using InstaConnect.Shared.Common.Utilities;

namespace InstaConnect.Shared.Application.Validators;

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
