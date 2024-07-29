using FluentValidation;

namespace InstaConnect.Identity.Business.Features.Users.Queries.GetUserById;

public class GetUserByIdQueryValidator : AbstractValidator<GetUserByIdQuery>
{
    public GetUserByIdQueryValidator()
    {
        RuleFor(q => q.Id)
            .NotEmpty();
    }
}
