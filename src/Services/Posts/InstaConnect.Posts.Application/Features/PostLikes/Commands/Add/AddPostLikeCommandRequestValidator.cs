namespace InstaConnect.Posts.Application.Features.PostLikes.Commands.Add;
public class AddPostLikeCommandRequestValidator : AbstractValidator<AddPostLikeCommandRequest>
{
    public AddPostLikeCommandRequestValidator()
    {
        RuleFor(r => r.Id.Id)
            .NotEmptyWithMessage()
            .PostIdMinLengthWithMessage()
            .PostIdMaxLengthWithMessage();

        RuleFor(r => r.UserId.Id)
            .NotEmptyWithMessage()
            .UserIdMinLengthWithMessage()
            .UserIdMaxLengthWithMessage();
    }
}
