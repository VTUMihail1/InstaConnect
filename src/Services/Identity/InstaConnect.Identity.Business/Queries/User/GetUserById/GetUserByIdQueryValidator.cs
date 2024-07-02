using FluentValidation;

namespace InstaConnect.Identity.Business.Queries.User.GetUserById;

public class GetUserByIdQueryValidator : AbstractValidator<GetUserByIdQuery>
{
    public GetUserByIdQueryValidator()
    {
        RuleFor(q => q.Id)
            .NotEmpty();
    }
}
