using FluentValidation;
using InstaConnect.Follows.Business.Features.Follows.Utilities;
using InstaConnect.Posts.Data.Features.PostCommentLikes.Models.Entitites;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Validators;

namespace InstaConnect.Posts.Business.Features.PostCommentLikes.Queries.GetAllFilteredPostCommentLikes;

public class GetAllFilteredPostCommentLikesQueryValidator : AbstractValidator<GetAllFilteredPostCommentLikesQuery>
{
    public GetAllFilteredPostCommentLikesQueryValidator(IEntityPropertyValidator entityPropertyValidator)
    {
        Include(new CollectionModelValidator());

        RuleFor(c => c.UserId)
            .MinimumLength(PostCommentLikeBusinessConfigurations.CURRENT_USER_ID_MIN_LENGTH)
            .MaximumLength(PostCommentLikeBusinessConfigurations.CURRENT_USER_ID_MAX_LENGTH)
            .When(q => !string.IsNullOrEmpty(q.UserId));

        RuleFor(c => c.UserName)
            .MinimumLength(PostCommentLikeBusinessConfigurations.CURRENT_USER_NAME_MIN_LENGTH)
            .MaximumLength(PostCommentLikeBusinessConfigurations.CURRENT_USER_NAME_MAX_LENGTH)
            .When(q => !string.IsNullOrEmpty(q.UserName));

        RuleFor(c => c.PostCommentId)
            .MinimumLength(PostCommentLikeBusinessConfigurations.POST_COMMENT_ID_MIN_LENGTH)
            .MaximumLength(PostCommentLikeBusinessConfigurations.POST_COMMENT_ID_MAX_LENGTH)
            .When(q => !string.IsNullOrEmpty(q.PostCommentId));

        RuleFor(c => c.SortPropertyName)
            .Must(entityPropertyValidator.IsEntityPropertyValid<PostCommentLike>);
    }
}
