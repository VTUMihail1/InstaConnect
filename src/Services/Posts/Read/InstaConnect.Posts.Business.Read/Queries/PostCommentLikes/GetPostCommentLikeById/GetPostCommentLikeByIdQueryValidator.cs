using FluentValidation;
using InstaConnect.Posts.Business.Read.Queries.PostCommentLikes.GetPostCommentLikeById;

namespace InstaConnect.Identity.Business.Commands.Account.ConfirmAccountEmail;

public class GetPostCommentLikeByIdQueryValidator : AbstractValidator<GetPostCommentLikeByIdQuery>
{
    public GetPostCommentLikeByIdQueryValidator()
    {
        RuleFor(q => q.Id)
            .NotEmpty();
    }
}
