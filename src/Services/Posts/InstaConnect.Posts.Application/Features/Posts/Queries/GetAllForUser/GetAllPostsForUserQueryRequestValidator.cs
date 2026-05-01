namespace InstaConnect.Posts.Application.Features.Posts.Queries.GetAllForUser;

public class GetAllPostsForUserQueryRequestValidator : AbstractValidator<GetAllPostsForUserQueryRequest>
{
	public GetAllPostsForUserQueryRequestValidator()
	{
		RuleFor(c => c.UserId)
			.NotEmptyWithMessage()
			.UserIdMinLengthWithMessage()
			.UserIdMaxLengthWithMessage();

		RuleFor(c => c.Title)
			.PostTitleMaxLengthWithMessage();

		RuleFor(c => c.CurrentUserId)
			.UserIdMaxLengthWithMessage();

		RuleFor(q => q.SortOrder)
			.NotEmptyWithMessage();

		RuleFor(q => q.SortTerm)
			.NotEmptyWithMessage();

		RuleFor(q => q.Page)
			.PostPageMinValueWithMessage()
			.PostPageMaxValueWithMessage();

		RuleFor(q => q.PageSize)
			.PostPageSizeMinValueWithMessage()
			.PostPageSizeMaxValueWithMessage();
	}
}
