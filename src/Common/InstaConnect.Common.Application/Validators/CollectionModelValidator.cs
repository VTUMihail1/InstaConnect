using FluentValidation;

using InstaConnect.Common.Application.Models.Filters;
using InstaConnect.Common.Utilities;

namespace InstaConnect.Common.Application.Validators;

public class CollectionModelValidator : AbstractValidator<CollectionModel>
{
    public CollectionModelValidator()
    {
        RuleFor(q => q.SortPropertyName)
            .NotEmpty()
            .MinimumLength(SharedConfigurations.SortPropertyMinLength)
            .MaximumLength(SharedConfigurations.SortPropertyMaxLength);

        RuleFor(q => q.Page)
            .LessThanOrEqualTo(SharedConfigurations.PageMaxValue)
            .GreaterThanOrEqualTo(SharedConfigurations.PageMinValue);

        RuleFor(q => q.PageSize)
            .LessThanOrEqualTo(SharedConfigurations.PageSizeMaxValue)
            .GreaterThanOrEqualTo(SharedConfigurations.PageSizeMinValue);
    }
}
