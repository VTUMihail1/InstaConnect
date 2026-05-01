namespace InstaConnect.Posts.Application.Features.PostComments.Commands.Update;

public class UpdatePostCommentCommandRequestValidator : AbstractValidator<UpdatePostCommentCommandRequest>
{
	public UpdatePostCommentCommandRequestValidator()
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

		RuleFor(c => c.Content)
			.NotEmptyWithMessage()
			.PostTitleMinLengthWithMessage()
			.PostTitleMaxLengthWithMessage();
	}
}
