using InstaConnect.Common.Application.Utilities;

namespace InstaConnect.Posts.Application.Features.PostLikes.Queries.GetAll;

public class GetAllPostLikesQueryRequestValidator : AbstractValidator<GetAllPostLikesQueryRequest>
{
    public GetAllPostLikesQueryRequestValidator()
    {
        RuleFor(r => r.Filter.Id.Id)
            .NotEmptyWithMessage()
            .PostIdMinLengthWithMessage()
            .PostIdMaxLengthWithMessage();

        RuleFor(c => c.Filter.UserName.Value)
            .UserNameMaxLengthWithMessage();

        RuleFor(q => q.Sorting.Order)
            .NotEmptyWithMessage();

        RuleFor(q => q.Sorting.Property)
            .NotEmptyWithMessage();

        RuleFor(q => q.Pagination.Page)
            .NotEmptyWithMessage()
            .PostLikePageMinValueWithMessage()
            .PostLikePageMaxValueWithMessage();

        RuleFor(q => q.Pagination.PageSize)
            .NotEmptyWithMessage()
            .PostLikePageSizeMinValueWithMessage()
            .PostLikePageSizeMaxValueWithMessage();
    }
}
