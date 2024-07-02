using FluentValidation;
using InstaConnect.Posts.Business.Read.Queries.Posts.GetAllPosts;

namespace InstaConnect.Identity.Business.Commands.Account.ConfirmAccountEmail;

public class GetAllPostsQueryValidator : AbstractValidator<GetAllPostsQuery>
{
    public GetAllPostsQueryValidator()
    {
        RuleFor(q => q.Offset)
            .NotEmpty()
            .GreaterThanOrEqualTo(default(int));

        RuleFor(q => q.Limit)
            .NotEmpty()
            .GreaterThanOrEqualTo(default(int));

        RuleFor(q => q.SortOrder)
            .NotEmpty()
            .IsInEnum();

        RuleFor(q => q.SortPropertyName)
            .NotEmpty();
    }
}
