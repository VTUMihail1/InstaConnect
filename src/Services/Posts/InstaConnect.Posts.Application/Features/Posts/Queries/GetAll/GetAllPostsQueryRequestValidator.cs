using InstaConnect.Common.Application.Utilities;

namespace InstaConnect.Posts.Application.Features.Posts.Queries.GetAll;

public class GetAllPostsQueryRequestValidator : AbstractValidator<GetAllPostsQueryRequest>
{
    public GetAllPostsQueryRequestValidator()
    {
        RuleFor(c => c.Filter.UserId.Id)
            .UserIdMaxLengthWithMessage();

        RuleFor(c => c.Filter.UserName.Value)
            .UserNameMaxLengthWithMessage();

        RuleFor(c => c.Filter.Title)
            .PostTitleMaxLengthWithMessage();

        RuleFor(q => q.Sorting.Order)
            .NotEmptyWithMessage();

        RuleFor(q => q.Sorting.Property)
            .NotEmptyWithMessage();

        RuleFor(q => q.Pagination.Page)
            .NotEmptyWithMessage()
            .PostPageMinValueWithMessage()
            .PostPageMaxValueWithMessage();

        RuleFor(q => q.Pagination.PageSize)
            .NotEmptyWithMessage()
            .PostPageSizeMinValueWithMessage()
            .PostPageSizeMaxValueWithMessage();
    }
}
