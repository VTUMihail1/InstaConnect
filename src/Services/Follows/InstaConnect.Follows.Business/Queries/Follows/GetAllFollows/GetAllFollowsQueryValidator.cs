using FluentValidation;
using InstaConnect.Follows.Data.Models.Entities;
using InstaConnect.Messages.Business.Utilities;
using InstaConnect.Messages.Read.Business.Queries.Messages.GetAllFilteredMessages;

namespace InstaConnect.Follows.Read.Business.Queries.Follows.GetAllFollows;
public class GetAllFollowsQueryValidator : AbstractValidator<GetAllFollowsQuery>
{
    public GetAllFollowsQueryValidator(IEntityPropertyValidator entityPropertyValidator)
    {
        RuleFor(q => q.SortOrder)
            .NotEmpty();

        RuleFor(q => q.SortPropertyName)
            .NotEmpty()
            .MinimumLength(FollowBusinessConfigurations.SORT_PROPERTY_NAME_MIN_LENGTH)
            .MaximumLength(FollowBusinessConfigurations.SORT_PROPERTY_NAME_MAX_LENGTH)
            .Must(entityPropertyValidator.IsEntityPropertyValid<Follow>);

        RuleFor(q => q.Page)
            .LessThanOrEqualTo(FollowBusinessConfigurations.PAGE_MAX_VALUE)
            .GreaterThanOrEqualTo(FollowBusinessConfigurations.PAGE_MIN_VALUE);

        RuleFor(q => q.PageSize)
            .LessThanOrEqualTo(FollowBusinessConfigurations.PAGE_SIZE_MAX_VALUE)
            .GreaterThanOrEqualTo(FollowBusinessConfigurations.PAGE_SIZE_MIN_VALUE);
    }
}
