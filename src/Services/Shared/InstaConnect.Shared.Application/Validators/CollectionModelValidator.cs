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
