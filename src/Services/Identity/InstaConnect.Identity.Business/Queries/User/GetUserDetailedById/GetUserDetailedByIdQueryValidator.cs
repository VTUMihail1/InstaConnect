using FluentValidation;

namespace InstaConnect.Identity.Business.Queries.User.GetUserDetailedById;

public class GetUserDetailedByIdQueryValidator : AbstractValidator<GetUserDetailedByIdQuery>
{
    public GetUserDetailedByIdQueryValidator()
    {
        RuleFor(q => q.Id)
            .NotEmpty();
    }
}
