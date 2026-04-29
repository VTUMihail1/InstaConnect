namespace InstaConnect.Posts.Application.Features.PostCommentLikes.Commands.Delete;

public class DeletePostCommentLikeCommandRequestValidator : AbstractValidator<DeletePostCommentLikeCommandRequest>
{
	public DeletePostCommentLikeCommandRequestValidator()
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
	}
}
