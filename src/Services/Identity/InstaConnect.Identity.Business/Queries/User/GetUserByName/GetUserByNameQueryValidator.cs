using FluentValidation;

namespace InstaConnect.Identity.Business.Queries.User.GetUserByName;

public class GetUserByNameQueryValidator : AbstractValidator<GetUserByNameQuery>
{
    public GetUserByNameQueryValidator()
    {
        RuleFor(q => q.UserName)
            .NotEmpty();
    }
}
