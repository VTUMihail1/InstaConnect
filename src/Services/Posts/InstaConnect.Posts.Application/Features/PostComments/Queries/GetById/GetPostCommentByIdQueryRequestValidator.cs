namespace InstaConnect.Posts.Application.Features.PostComments.Queries.GetById;

public class GetPostCommentByIdQueryRequestValidator : AbstractValidator<GetPostCommentByIdQueryRequest>
{
    public GetPostCommentByIdQueryRequestValidator()
    {
        RuleFor(r => r.Id.Id.Id)
            .NotEmptyWithMessage()
            .PostIdMinLengthWithMessage()
            .PostIdMaxLengthWithMessage();

        RuleFor(r => r.Id.CommentId)
            .NotEmptyWithMessage()
            .PostCommentIdMinLengthWithMessage()
            .PostCommentIdMaxLengthWithMessage();
    }
}
