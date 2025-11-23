using InstaConnect.Common.Application.Utilities;

namespace InstaConnect.Posts.Application.Features.PostComments.Queries.GetAll;

public class GetAllPostCommentsQueryRequestValidator : AbstractValidator<GetAllPostCommentsQueryRequest>
{
    public GetAllPostCommentsQueryRequestValidator()
    {
        RuleFor(r => r.Filter.Id.Id)
            .NotEmptyWithMessage()
            .PostIdMinLengthWithMessage()
            .PostIdMaxLengthWithMessage();

        RuleFor(r => r.Filter.UserId.Id)
            .UserIdMaxLengthWithMessage();

        RuleFor(c => c.Filter.UserName.Value)
            .UserNameMaxLengthWithMessage();

        RuleFor(q => q.Sorting.Order)
            .NotEmptyWithMessage();

        RuleFor(q => q.Sorting.Property)
            .NotEmptyWithMessage();

        RuleFor(q => q.Pagination.Page)
            .NotEmptyWithMessage()
            .PostCommentPageMinValueWithMessage()
            .PostCommentPageMaxValueWithMessage();

        RuleFor(q => q.Pagination.PageSize)
            .NotEmptyWithMessage()
            .PostCommentPageSizeMinValueWithMessage()
            .PostCommentPageSizeMaxValueWithMessage();
    }
}
