namespace InstaConnect.Posts.Application.Features.PostCommentLikes.Commands.Add;

public class AddPostCommentLikeCommandRequestValidator : AbstractValidator<AddPostCommentLikeCommandRequest>
{
	public AddPostCommentLikeCommandRequestValidator()
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
