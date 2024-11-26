using FluentValidation;
using InstaConnect.Posts.Common.Features.Posts.Utilities;
using InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.Entitites;
using InstaConnect.Shared.Application.Abstractions;
using InstaConnect.Shared.Application.Validators;

namespace InstaConnect.Posts.Application.Features.Posts.Queries.GetAllPosts;

public class GetAllPostsQueryValidator : AbstractValidator<GetAllPostsQuery>
{
    public GetAllPostsQueryValidator(IEntityPropertyValidator entityPropertyValidator)
    {
        Include(new CollectionModelValidator());

        RuleFor(c => c.UserId)
            .MinimumLength(PostBusinessConfigurations.CURRENT_USER_ID_MIN_LENGTH)
            .MaximumLength(PostBusinessConfigurations.CURRENT_USER_ID_MAX_LENGTH)
            .When(q => !string.IsNullOrEmpty(q.UserId));

        RuleFor(c => c.UserName)
            .MinimumLength(PostBusinessConfigurations.CURRENT_USER_NAME_MIN_LENGTH)
            .MaximumLength(PostBusinessConfigurations.CURRENT_USER_NAME_MAX_LENGTH)
            .When(q => !string.IsNullOrEmpty(q.UserName));

        RuleFor(c => c.Title)
            .MinimumLength(PostBusinessConfigurations.TITLE_MIN_LENGTH)
            .MaximumLength(PostBusinessConfigurations.TITLE_MAX_LENGTH)
            .When(q => !string.IsNullOrEmpty(q.Title));

        RuleFor(c => c.SortPropertyName)
            .Must(entityPropertyValidator.IsEntityPropertyValid<PostCommentLike>);
    }
}
