using FluentValidation;

namespace InstaConnect.Identity.Business.Features.Users.Queries.GetAllFilteredUsers;

public class GetAllFilteredUsersQueryValidator : AbstractValidator<GetAllFilteredUsersQuery>
{
    public GetAllFilteredUsersQueryValidator()
    {
        RuleFor(q => q.Page)
            .NotEmpty()
            .GreaterThanOrEqualTo(default(int));

        RuleFor(q => q.PageSize)
            .NotEmpty()
            .GreaterThanOrEqualTo(default(int));

        RuleFor(q => q.SortOrder)
            .NotEmpty()
            .IsInEnum();

        RuleFor(q => q.SortPropertyName)
            .NotEmpty();
    }
}
