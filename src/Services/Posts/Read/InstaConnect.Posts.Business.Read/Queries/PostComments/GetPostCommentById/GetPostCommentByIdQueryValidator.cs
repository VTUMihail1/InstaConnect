using FluentValidation;
using InstaConnect.Posts.Business.Read.Queries.PostCommentLikes.GetPostCommentLikeById;
using InstaConnect.Posts.Business.Read.Queries.PostComments.GetPostCommentById;

namespace InstaConnect.Identity.Business.Commands.Account.ConfirmAccountEmail;

public class GetPostCommentByIdQueryValidator : AbstractValidator<GetPostCommentByIdQuery>
{
    public GetPostCommentByIdQueryValidator()
    {
        RuleFor(q => q.Id)
            .NotEmpty();
    }
}
