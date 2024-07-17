using FluentValidation;

namespace InstaConnect.Identity.Business.Queries.User.GetAllFilteredUsers;

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
