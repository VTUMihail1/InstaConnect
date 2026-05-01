namespace InstaConnect.Posts.Application.Features.PostLikes.Commands.Delete;

public class DeletePostLikeCommandRequestValidator : AbstractValidator<DeletePostLikeCommandRequest>
{
	public DeletePostLikeCommandRequestValidator()
	{
		RuleFor(r => r.Id)
			.NotEmptyWithMessage()
			.PostIdMinLengthWithMessage()
			.PostIdMaxLengthWithMessage();

		RuleFor(r => r.UserId)
			.NotEmptyWithMessage()
			.UserIdMinLengthWithMessage()
			.UserIdMaxLengthWithMessage();
	}
}
