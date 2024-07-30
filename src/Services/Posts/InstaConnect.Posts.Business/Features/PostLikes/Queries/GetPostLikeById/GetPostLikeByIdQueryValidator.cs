using FluentValidation;
using InstaConnect.Follows.Business.Features.Follows.Utilities;

namespace InstaConnect.Posts.Business.Features.PostLikes.Queries.GetPostLikeById;

public class GetPostLikeByIdQueryValidator : AbstractValidator<GetPostLikeByIdQuery>
{
    public GetPostLikeByIdQueryValidator()
    {
        RuleFor(q => q.Id)
            .NotEmpty()
            .MinimumLength(PostLikeBusinessConfigurations.ID_MIN_LENGTH)
            .MaximumLength(PostLikeBusinessConfigurations.ID_MAX_LENGTH);
    }
}
