using FluentValidation;

namespace InstaConnect.Posts.Business.Read.Queries.PostCommentLikes.GetPostCommentLikeById;

public class GetPostCommentLikeByIdQueryValidator : AbstractValidator<GetPostCommentLikeByIdQuery>
{
    public GetPostCommentLikeByIdQueryValidator()
    {
        RuleFor(q => q.Id)
            .NotEmpty();
    }
}
