﻿using FluentValidation;
using InstaConnect.Follows.Data.Models.Entities;
using InstaConnect.Messages.Business.Utilities;
using InstaConnect.Messages.Read.Business.Queries.Messages.GetAllFilteredMessages;

namespace InstaConnect.Follows.Read.Business.Queries.Follows.GetAllFilteredFollows;
public class GetAllFilteredFollowsQueryValidator : AbstractValidator<GetAllFilteredFollowsQuery>
{
    public GetAllFilteredFollowsQueryValidator(
        IEntityPropertyValidator entityPropertyValidator)
    {
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
