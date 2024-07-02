using FluentValidation;
using InstaConnect.Posts.Business.Read.Queries.PostLikes.GetPostLikeById;

namespace InstaConnect.Identity.Business.Commands.Account.ConfirmAccountEmail;

public class GetPostLikeByIdQueryValidator : AbstractValidator<GetPostLikeByIdQuery>
{
    public GetPostLikeByIdQueryValidator()
    {
        RuleFor(q => q.Id)
            .NotEmpty();
    }
}
