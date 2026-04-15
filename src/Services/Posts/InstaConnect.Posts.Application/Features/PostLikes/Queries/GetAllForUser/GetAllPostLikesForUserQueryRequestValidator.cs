namespace InstaConnect.Posts.Application.Features.PostLikes.Queries.GetAllForUser;

public class GetAllPostLikesForUserQueryRequestValidator : AbstractValidator<GetAllPostLikesForUserQueryRequest>
{
    public GetAllPostLikesForUserQueryRequestValidator()
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
            .PostLikePageMinValueWithMessage()
            .PostLikePageMaxValueWithMessage();

        RuleFor(q => q.PageSize)
            .PostLikePageSizeMinValueWithMessage()
            .PostLikePageSizeMaxValueWithMessage();
    }
}
