using FluentValidation;
using InstaConnect.Posts.Common.Features.PostLikes.Utilities;
using InstaConnect.Posts.Common.Features.Posts.Utilities;
using InstaConnect.Posts.Common.Features.Users.Utilities;
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
            .MinimumLength(UserConfigurations.IdMinLength)
            .MaximumLength(UserConfigurations.IdMaxLength)
            .When(q => !string.IsNullOrEmpty(q.UserId));

        RuleFor(c => c.UserName)
            .MinimumLength(UserConfigurations.NameMinLength)
            .MaximumLength(UserConfigurations.NameMaxLength)
            .When(q => !string.IsNullOrEmpty(q.UserName));

        RuleFor(c => c.PostId)
            .MinimumLength(PostConfigurations.IdMinLength)
            .MaximumLength(PostConfigurations.IdMaxLength)
            .When(q => !string.IsNullOrEmpty(q.PostId));

        RuleFor(c => c.SortPropertyName)
            .Must(entityPropertyValidator.IsEntityPropertyValid<PostCommentLike>);
    }
}
