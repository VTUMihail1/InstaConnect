using FluentValidation;
using InstaConnect.Follows.Common.Features.Follows.Utilities;
using InstaConnect.Follows.Data.Features.Follows.Models.Entities;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Validators;

namespace InstaConnect.Follows.Business.Features.Follows.Queries.GetAllFollows;
public class GetAllFollowsQueryValidator : AbstractValidator<GetAllFollowsQuery>
{
    public GetAllFollowsQueryValidator(
        IEntityPropertyValidator entityPropertyValidator)
    {
        Include(new CollectionModelValidator());

        RuleFor(q => q.FollowerId)
            .MinimumLength(FollowBusinessConfigurations.CURRENT_USER_ID_MIN_LENGTH)
            .MaximumLength(FollowBusinessConfigurations.CURRENT_USER_ID_MAX_LENGTH)
            .When(q => !string.IsNullOrEmpty(q.FollowerId));

        RuleFor(q => q.FollowerName)
            .MinimumLength(FollowBusinessConfigurations.CURRENT_USER_NAME_MIN_LENGTH)
            .MaximumLength(FollowBusinessConfigurations.CURRENT_USER_NAME_MAX_LENGTH)
            .When(q => !string.IsNullOrEmpty(q.FollowerName));

        RuleFor(q => q.FollowingId)
            .MinimumLength(FollowBusinessConfigurations.FOLLOWING_ID_MIN_LENGTH)
            .MaximumLength(FollowBusinessConfigurations.FOLLOWING_ID_MAX_LENGTH)
            .When(q => !string.IsNullOrEmpty(q.FollowingId));

        RuleFor(q => q.FollowingName)
            .MinimumLength(FollowBusinessConfigurations.FOLLOWING_NAME_MIN_LENGTH)
            .MaximumLength(FollowBusinessConfigurations.FOLLOWING_NAME_MAX_LENGTH)
            .When(q => !string.IsNullOrEmpty(q.FollowingName));

        RuleFor(q => q.SortPropertyName)
            .Must(entityPropertyValidator.IsEntityPropertyValid<Follow>);
    }
}
