namespace InstaConnect.Posts.Application.Features.PostCommentLikes.Queries.GetById;

public class GetPostCommentLikeByIdQueryValidator : AbstractValidator<GetPostCommentLikeByIdQuery>
{
    public GetPostCommentLikeByIdQueryValidator()
    {
        RuleFor(q => q.Id)
            .NotEmpty()
            .MinimumLength(PostCommentLikeConfigurations.IdMinLength)
            .MaximumLength(PostCommentLikeConfigurations.IdMaxLength);
    }
}
