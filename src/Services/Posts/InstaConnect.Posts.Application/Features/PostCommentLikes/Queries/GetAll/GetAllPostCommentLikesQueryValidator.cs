using FluentValidation;
using InstaConnect.Posts.Common.Features.PostComments.Utilities;
using InstaConnect.Posts.Common.Features.Users.Utilities;
using InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.Entitites;
using InstaConnect.Shared.Application.Abstractions;
using InstaConnect.Shared.Application.Validators;

namespace InstaConnect.Posts.Application.Features.PostCommentLikes.Queries.GetAll;

public class GetAllPostCommentLikesQueryValidator : AbstractValidator<GetAllPostCommentLikesQuery>
{
    public GetAllPostCommentLikesQueryValidator(IEntityPropertyValidator entityPropertyValidator)
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

        RuleFor(c => c.PostCommentId)
            .MinimumLength(PostCommentConfigurations.IdMinLength)
            .MaximumLength(PostCommentConfigurations.IdMaxLength)
            .When(q => !string.IsNullOrEmpty(q.PostCommentId));

        RuleFor(c => c.SortPropertyName)
            .Must(entityPropertyValidator.IsEntityPropertyValid<PostCommentLike>);
    }
}
