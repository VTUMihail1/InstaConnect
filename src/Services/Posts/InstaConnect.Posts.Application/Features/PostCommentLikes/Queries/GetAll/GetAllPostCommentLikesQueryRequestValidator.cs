namespace InstaConnect.Posts.Application.Features.PostCommentLikes.Queries.GetAll;

public class GetAllPostCommentLikesQueryRequestValidator : AbstractValidator<GetAllPostCommentLikesQueryRequest>
{
    public GetAllPostCommentLikesQueryRequestValidator()
    {
        RuleFor(r => r.Filter.Id.Id.Id)
            .NotEmptyWithMessage()
            .PostIdMinLengthWithMessage()
            .PostIdMaxLengthWithMessage();

        RuleFor(r => r.Filter.Id.CommentId)
            .NotEmptyWithMessage()
            .PostIdMinLengthWithMessage()
            .PostIdMaxLengthWithMessage();

        RuleFor(c => c.Filter.UserName.Value)
            .UserNameMaxLengthWithMessage();

        RuleFor(q => q.Sorting.Order)
            .NotEmptyWithMessage();

        RuleFor(q => q.Sorting.Property)
            .NotEmptyWithMessage();

        RuleFor(q => q.Pagination.Page)
            .NotEmptyWithMessage()
            .PostLikePageMinValueWithMessage()
            .PostLikePageMaxValueWithMessage();

        RuleFor(q => q.Pagination.PageSize)
            .NotEmptyWithMessage()
            .PostCommentLikePageSizeMinValueWithMessage()
            .PostCommentLikePageSizeMaxValueWithMessage();
    }
}
