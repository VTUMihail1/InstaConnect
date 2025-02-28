using InstaConnect.Common.Application.Validators;

namespace InstaConnect.Posts.Application.Features.PostComments.Queries.GetAll;

public class GetAllPostCommentsQueryValidator : AbstractValidator<GetAllPostCommentsQuery>
{
    public GetAllPostCommentsQueryValidator(IEntityPropertyValidator entityPropertyValidator)
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
