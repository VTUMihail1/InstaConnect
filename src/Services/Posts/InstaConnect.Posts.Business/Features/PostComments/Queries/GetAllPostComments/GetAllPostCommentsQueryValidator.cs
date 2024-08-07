using FluentValidation;
using InstaConnect.Posts.Business.Features.PostComments.Utilities;
using InstaConnect.Posts.Data.Features.PostCommentLikes.Models.Entitites;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Validators;

namespace InstaConnect.Posts.Business.Features.PostComments.Queries.GetAllFilteredPostComments;

public class GetAllPostCommentsQueryValidator : AbstractValidator<GetAllPostCommentsQuery>
{
    public GetAllPostCommentsQueryValidator(IEntityPropertyValidator entityPropertyValidator)
    {
        Include(new CollectionModelValidator());

        RuleFor(c => c.UserId)
            .MinimumLength(PostCommentBusinessConfigurations.CURRENT_USER_ID_MIN_LENGTH)
            .MaximumLength(PostCommentBusinessConfigurations.CURRENT_USER_ID_MAX_LENGTH)
            .When(q => !string.IsNullOrEmpty(q.UserId));

        RuleFor(c => c.UserName)
            .MinimumLength(PostCommentBusinessConfigurations.CURRENT_USER_NAME_MIN_LENGTH)
            .MaximumLength(PostCommentBusinessConfigurations.CURRENT_USER_NAME_MAX_LENGTH)
            .When(q => !string.IsNullOrEmpty(q.UserName));

        RuleFor(c => c.PostId)
            .MinimumLength(PostCommentBusinessConfigurations.POST_ID_MIN_LENGTH)
            .MaximumLength(PostCommentBusinessConfigurations.POST_ID_MAX_LENGTH)
            .When(q => !string.IsNullOrEmpty(q.PostId));

        RuleFor(c => c.SortPropertyName)
            .Must(entityPropertyValidator.IsEntityPropertyValid<PostCommentLike>);
    }
}
