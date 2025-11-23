namespace InstaConnect.Posts.Application.Features.PostCommentLikes.Queries.GetById;

public class GetPostCommentLikeByIdQueryRequestValidator : AbstractValidator<GetPostCommentLikeByIdQueryRequest>
{
    public GetPostCommentLikeByIdQueryRequestValidator()
    {
        RuleFor(r => r.Id.CommentId.Id.Id)
            .NotEmptyWithMessage()
            .PostIdMinLengthWithMessage()
            .PostIdMaxLengthWithMessage();

        RuleFor(r => r.Id.CommentId.CommentId)
            .NotEmptyWithMessage()
            .PostCommentIdMinLengthWithMessage()
            .PostCommentIdMaxLengthWithMessage();

        RuleFor(r => r.Id.UserId.Id)
            .NotEmptyWithMessage()
            .UserIdMinLengthWithMessage()
            .UserIdMaxLengthWithMessage();
    }
}
