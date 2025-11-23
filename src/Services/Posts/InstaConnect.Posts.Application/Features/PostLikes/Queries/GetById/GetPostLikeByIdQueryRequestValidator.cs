namespace InstaConnect.Posts.Application.Features.PostLikes.Queries.GetById;

public class GetPostLikeByIdQueryRequestValidator : AbstractValidator<GetPostLikeByIdQueryRequest>
{
    public GetPostLikeByIdQueryRequestValidator()
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
