namespace InstaConnect.Posts.Application.Features.PostLikes.Queries.GetAll;

public class GetAllPostLikesQueryRequestValidator : AbstractValidator<GetAllPostLikesQueryRequest>
{
    public GetAllPostLikesQueryRequestValidator()
    {
        RuleFor(r => r.Id)
            .NotEmptyWithMessage()
            .PostIdMinLengthWithMessage()
            .PostIdMaxLengthWithMessage();

        RuleFor(c => c.UserName)
            .UserNameMaxLengthWithMessage();

        RuleFor(q => q.SortOrder)
            .NotEmptyWithMessage();

        RuleFor(q => q.SortProperty)
            .NotEmptyWithMessage();

        RuleFor(q => q.Page)
            .PostLikePageMinValueWithMessage()
            .PostLikePageMaxValueWithMessage();

        RuleFor(q => q.PageSize)
            .PostLikePageSizeMinValueWithMessage()
            .PostLikePageSizeMaxValueWithMessage();
    }
}
