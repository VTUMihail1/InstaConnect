namespace InstaConnect.Posts.Application.Features.Posts.Queries.GetAll;

public class GetAllPostsQueryRequestValidator : AbstractValidator<GetAllPostsQueryRequest>
{
    public GetAllPostsQueryRequestValidator()
    {
        RuleFor(c => c.UserName)
            .UserNameMaxLengthWithMessage();

        RuleFor(c => c.Title)
            .PostTitleMaxLengthWithMessage();

        RuleFor(q => q.SortOrder)
            .NotEmptyWithMessage();

        RuleFor(q => q.SortProperty)
            .NotEmptyWithMessage();

        RuleFor(q => q.Page)
            .PostPageMinValueWithMessage()
            .PostPageMaxValueWithMessage();

        RuleFor(q => q.PageSize)
            .PostPageSizeMinValueWithMessage()
            .PostPageSizeMaxValueWithMessage();
    }
}
