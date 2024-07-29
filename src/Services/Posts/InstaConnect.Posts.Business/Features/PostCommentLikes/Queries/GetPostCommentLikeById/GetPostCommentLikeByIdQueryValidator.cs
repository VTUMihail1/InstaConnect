using FluentValidation;

namespace InstaConnect.Posts.Business.Features.PostCommentLikes.Queries.GetPostCommentLikeById;

public class GetPostCommentLikeByIdQueryValidator : AbstractValidator<GetPostCommentLikeByIdQuery>
{
    public GetPostCommentLikeByIdQueryValidator()
    {
        RuleFor(q => q.Id)
            .NotEmpty();
    }
}
