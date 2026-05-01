namespace InstaConnect.Posts.Application.Features.PostComments.Queries.GetAllForUser;

public class GetAllPostCommentsForUserQueryRequestValidator : AbstractValidator<GetAllPostCommentsForUserQueryRequest>
{
	public GetAllPostCommentsForUserQueryRequestValidator()
	{
		RuleFor(c => c.UserId)
			.NotEmptyWithMessage()
			.UserIdMinLengthWithMessage()
			.UserIdMaxLengthWithMessage();

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
			.PostCommentPageSizeMinValueWithMessage()
			.PostCommentPageSizeMaxValueWithMessage();
	}
}
