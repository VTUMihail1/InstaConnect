namespace InstaConnect.Posts.Application.Features.PostCommentLikes.Queries.GetById;

public class GetPostCommentLikeByIdQueryRequestValidator : AbstractValidator<GetPostCommentLikeByIdQueryRequest>
{
	public GetPostCommentLikeByIdQueryRequestValidator()
	{
		RuleFor(r => r.Id)
			.NotEmptyWithMessage()
			.PostIdMinLengthWithMessage()
			.PostIdMaxLengthWithMessage();

		RuleFor(r => r.CommentId)
			.NotEmptyWithMessage()
			.PostCommentIdMinLengthWithMessage()
			.PostCommentIdMaxLengthWithMessage();

		RuleFor(r => r.UserId)
			.NotEmptyWithMessage()
			.UserIdMinLengthWithMessage()
			.UserIdMaxLengthWithMessage();

		RuleFor(c => c.CurrentUserId)
			.UserIdMaxLengthWithMessage();
	}
}
