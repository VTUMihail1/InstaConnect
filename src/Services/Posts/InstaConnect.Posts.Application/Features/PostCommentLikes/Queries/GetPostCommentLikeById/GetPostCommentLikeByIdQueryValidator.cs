using FluentValidation;
using InstaConnect.Posts.Common.Features.PostCommentLikes.Utilities;

namespace InstaConnect.Posts.Application.Features.PostCommentLikes.Queries.GetPostCommentLikeById;

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
