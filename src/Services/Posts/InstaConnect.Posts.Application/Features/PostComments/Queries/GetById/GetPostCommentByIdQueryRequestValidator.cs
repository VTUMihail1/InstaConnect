namespace InstaConnect.Posts.Application.Features.PostComments.Queries.GetById;

public class GetPostCommentByIdQueryRequestValidator : AbstractValidator<GetPostCommentByIdQueryRequest>
{
    public GetPostCommentByIdQueryRequestValidator()
    {
        RuleFor(r => r.Id)
            .NotEmptyWithMessage()
            .PostIdMinLengthWithMessage()
            .PostIdMaxLengthWithMessage();

        RuleFor(r => r.CommentId)
            .NotEmptyWithMessage()
            .PostCommentIdMinLengthWithMessage()
            .PostCommentIdMaxLengthWithMessage();

        RuleFor(c => c.CurrentUserId)
            .UserIdMaxLengthWithMessage();
    }
}
