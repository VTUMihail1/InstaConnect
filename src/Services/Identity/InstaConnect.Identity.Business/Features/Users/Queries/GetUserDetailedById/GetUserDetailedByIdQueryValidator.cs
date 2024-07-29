using FluentValidation;

namespace InstaConnect.Identity.Business.Features.Users.Queries.GetUserDetailedById;

public class GetUserDetailedByIdQueryValidator : AbstractValidator<GetUserDetailedByIdQuery>
{
    public GetUserDetailedByIdQueryValidator()
    {
        RuleFor(q => q.Id)
            .NotEmpty();
    }
}
