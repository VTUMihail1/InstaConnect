namespace InstaConnect.Posts.Application.Features.PostComments.Queries.GetAll;

public class GetAllPostCommentsQueryRequestValidator : AbstractValidator<GetAllPostCommentsQueryRequest>
{
    public GetAllPostCommentsQueryRequestValidator()
    {
        RuleFor(r => r.Id)
            .NotEmptyWithMessage()
            .PostIdMinLengthWithMessage()
            .PostIdMaxLengthWithMessage();

        RuleFor(c => c.UserName)
            .UserNameMaxLengthWithMessage();

        RuleFor(q => q.SortOrder)
            .NotEmptyWithMessage();

        RuleFor(q => q.SortTerm)
            .NotEmptyWithMessage();

        RuleFor(q => q.Page)
            .PostCommentPageMinValueWithMessage()
            .PostCommentPageMaxValueWithMessage();

        RuleFor(q => q.PageSize)
            .PostCommentPageSizeMinValueWithMessage()
            .PostCommentPageSizeMaxValueWithMessage();

        RuleFor(c => c.CurrentUserId)
            .UserIdMaxLengthWithMessage();
    }
}
