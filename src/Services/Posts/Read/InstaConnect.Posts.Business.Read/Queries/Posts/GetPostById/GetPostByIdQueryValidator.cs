using FluentValidation;
using InstaConnect.Posts.Business.Read.Queries.Posts.GetPostById;

namespace InstaConnect.Identity.Business.Commands.Account.ConfirmAccountEmail;

public class GetPostByIdQueryValidator : AbstractValidator<GetPostByIdQuery>
{
    public GetPostByIdQueryValidator()
    {
        RuleFor(q => q.Id)
            .NotEmpty();
    }
}
