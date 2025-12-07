namespace InstaConnect.Posts.Application.Features.PostCommentLikes.Queries.GetAll;

public class GetAllPostCommentLikesQueryRequestValidator : AbstractValidator<GetAllPostCommentLikesQueryRequest>
{
    public GetAllPostCommentLikesQueryRequestValidator()
    {
        RuleFor(r => r.Id)
            .NotEmptyWithMessage()
            .PostIdMinLengthWithMessage()
            .PostIdMaxLengthWithMessage();

        RuleFor(r => r.CommentId)
            .NotEmptyWithMessage()
            .PostIdMinLengthWithMessage()
            .PostIdMaxLengthWithMessage();

        RuleFor(c => c.UserName)
            .UserNameMaxLengthWithMessage();

        RuleFor(q => q.SortOrder)
            .NotEmptyWithMessage();

        RuleFor(q => q.SortProperty)
            .NotEmptyWithMessage();

        RuleFor(q => q.Page)
            .PostLikePageMinValueWithMessage()
            .PostLikePageMaxValueWithMessage();

        RuleFor(q => q.PageSize)
            .PostCommentLikePageSizeMinValueWithMessage()
            .PostCommentLikePageSizeMaxValueWithMessage();
    }
}
