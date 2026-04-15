namespace InstaConnect.Posts.Application.Features.PostLikes.Queries.GetById;

public class GetPostLikeByIdQueryRequestValidator : AbstractValidator<GetPostLikeByIdQueryRequest>
{
    public GetPostLikeByIdQueryRequestValidator()
    {
        RuleFor(r => r.Id)
            .NotEmptyWithMessage()
            .PostIdMinLengthWithMessage()
            .PostIdMaxLengthWithMessage();

        RuleFor(r => r.UserId)
            .NotEmptyWithMessage()
            .UserIdMinLengthWithMessage()
            .UserIdMaxLengthWithMessage();

        RuleFor(c => c.CurrentUserId)
            .UserIdMaxLengthWithMessage();
    }
}
