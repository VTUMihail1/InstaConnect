using FluentValidation;
using InstaConnect.Posts.Common.Features.PostLikes.Utilities;
using InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.Entitites;
using InstaConnect.Shared.Application.Abstractions;
using InstaConnect.Shared.Application.Validators;

namespace InstaConnect.Posts.Application.Features.PostLikes.Queries.GetAllPostLikes;

public class GetAllPostLikesQueryValidator : AbstractValidator<GetAllPostLikesQuery>
{
    public GetAllPostLikesQueryValidator(IEntityPropertyValidator entityPropertyValidator)
    {
        Include(new CollectionModelValidator());

        RuleFor(c => c.UserId)
            .MinimumLength(PostLikeBusinessConfigurations.CURRENT_USER_ID_MIN_LENGTH)
            .MaximumLength(PostLikeBusinessConfigurations.CURRENT_USER_ID_MAX_LENGTH)
            .When(q => !string.IsNullOrEmpty(q.UserId));

        RuleFor(c => c.UserName)
            .MinimumLength(PostLikeBusinessConfigurations.CURRENT_USER_NAME_MIN_LENGTH)
            .MaximumLength(PostLikeBusinessConfigurations.CURRENT_USER_NAME_MAX_LENGTH)
            .When(q => !string.IsNullOrEmpty(q.UserName));

        RuleFor(c => c.PostId)
            .MinimumLength(PostLikeBusinessConfigurations.POST_ID_MIN_LENGTH)
            .MaximumLength(PostLikeBusinessConfigurations.POST_ID_MAX_LENGTH)
            .When(q => !string.IsNullOrEmpty(q.PostId));

        RuleFor(c => c.SortPropertyName)
            .Must(entityPropertyValidator.IsEntityPropertyValid<PostCommentLike>);
    }
}
