using FluentValidation;
using InstaConnect.Posts.Data.Features.PostCommentLikes.Models.Entitites;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Validators;

namespace InstaConnect.Posts.Business.Features.PostComments.Queries.GetAllPostComments;

public class GetAllPostCommentsQueryValidator : AbstractValidator<GetAllPostCommentsQuery>
{
    public GetAllPostCommentsQueryValidator(IEntityPropertyValidator entityPropertyValidator)
    {
        Include(new CollectionModelValidator());

        RuleFor(c => c.SortPropertyName)
            .Must(entityPropertyValidator.IsEntityPropertyValid<PostCommentLike>);
    }
}
