namespace InstaConnect.Posts.Application.Features.PostLikes.Commands.Delete;
public class DeletePostLikeCommandRequestValidator : AbstractValidator<DeletePostLikeCommandRequest>
{
    public DeletePostLikeCommandRequestValidator()
    {
        RuleFor(r => r.Id.Id.Id)
            .NotEmptyWithMessage()
            .PostIdMinLengthWithMessage()
            .PostIdMaxLengthWithMessage();

        RuleFor(r => r.Id.UserId.Id)
            .NotEmptyWithMessage()
            .UserIdMinLengthWithMessage()
            .UserIdMaxLengthWithMessage();
    }
}
