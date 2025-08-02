using InstaConnect.Common.Utilities;
using InstaConnect.PostLikes.Common.Features.PostLikes.Utilities;
using InstaConnect.Posts.Domain.Features.Users.Utilities;

namespace InstaConnect.PostLikes.Application.Features.PostLikes.Queries.GetAll;

public class GetAllPostLikesQueryRequestValidator : AbstractValidator<GetAllPostLikesQueryRequest>
{
    public GetAllPostLikesQueryRequestValidator()
    {
        RuleFor(r => r.Filter.Id)
            .NotEmpty()
            .WithMessage(PostErrorMessages.GetIdEmpty())
            .MinimumLength(PostConfigurations.IdMinLength)
            .WithMessage(r => PostErrorMessages.GetIdTooShort(r.Filter.Id.Length))
            .MaximumLength(PostConfigurations.IdMaxLength)
            .WithMessage(r => PostErrorMessages.GetIdTooLong(r.Filter.Id.Length));

        RuleFor(c => c.Filter.UserId)
            .MaximumLength(UserConfigurations.IdMaxLength)
            .WithMessage(q => UserErrorMessages.GetIdTooLong(q.Filter.UserId.Length));

        RuleFor(c => c.Filter.UserName)
            .MaximumLength(UserConfigurations.NameMaxLength)
            .WithMessage(q => UserErrorMessages.GetNameTooLong(q.Filter.UserName.Length));

        RuleFor(q => q.Sorting.Order)
            .NotEmpty()
            .WithMessage(CommonErrorMessages.GetSortOrderEmpty());

        RuleFor(q => q.Sorting.Property)
            .NotEmpty()
            .WithMessage(PostLikeErrorMessages.GetSortPropertyEmpty());

        RuleFor(q => q.Pagination.Page)
            .NotEmpty()
            .WithMessage(PostLikeErrorMessages.GetPageEmpty())
            .GreaterThanOrEqualTo(PostLikeConfigurations.PageMinValue)
            .WithMessage(q => PostLikeErrorMessages.GetPageTooSmall(q.Pagination.Page))
            .LessThanOrEqualTo(PostLikeConfigurations.PageMaxValue)
            .WithMessage(q => PostLikeErrorMessages.GetPageTooLarge(q.Pagination.Page));

        RuleFor(q => q.Pagination.PageSize)
            .NotEmpty()
            .WithMessage(PostLikeErrorMessages.GetPageSizeEmpty())
            .GreaterThanOrEqualTo(PostLikeConfigurations.PageSizeMinValue)
            .WithMessage(q => PostLikeErrorMessages.GetPageSizeTooSmall(q.Pagination.PageSize))
            .LessThanOrEqualTo(PostLikeConfigurations.PageSizeMaxValue)
            .WithMessage(q => PostLikeErrorMessages.GetPageSizeTooLarge(q.Pagination.PageSize));
    }
}
