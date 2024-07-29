using FluentValidation;

namespace InstaConnect.Identity.Business.Features.Users.Queries.GetAllUsers;

public class GetAllUsersQueryValidator : AbstractValidator<GetAllUsersQuery>
{
    public GetAllUsersQueryValidator()
    {
        RuleFor(q => q.Page)
            .NotEmpty()
            .GreaterThanOrEqualTo(default(int));

        RuleFor(q => q.PageSize)
            .NotEmpty()
            .GreaterThanOrEqualTo(default(int));

        RuleFor(q => q.SortOrder)
            .NotEmpty();

        RuleFor(q => q.SortPropertyName)
            .NotEmpty();
    }
}
