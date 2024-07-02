using FluentValidation;

namespace InstaConnect.Identity.Business.Queries.User.GetCurrentUserDetailed;

public class GetCurrentUserDetailedQueryValidator : AbstractValidator<GetCurrentUserDetailedQuery>
{
    public GetCurrentUserDetailedQueryValidator()
    {
        RuleFor(q => q.CurrentUserId)
            .NotEmpty();

        RuleFor(q => q.Key)
            .NotEmpty();

        RuleFor(q => q.Expiration)
            .NotEmpty();
    }
}
