using FluentValidation;
using InstaConnect.Follows.Business.Features.Follows.Utilities;

namespace InstaConnect.Posts.Business.Features.PostCommentLikes.Queries.GetPostCommentLikeById;

public class GetPostCommentLikeByIdQueryValidator : AbstractValidator<GetPostCommentLikeByIdQuery>
{
    public GetPostCommentLikeByIdQueryValidator()
    {
        RuleFor(q => q.Id)
            .NotEmpty()
            .MinimumLength(PostCommentLikeBusinessConfigurations.ID_MIN_LENGTH)
            .MaximumLength(PostCommentLikeBusinessConfigurations.ID_MAX_LENGTH);
        ;
    }
}
