using FluentValidation;

namespace InstaConnect.Posts.Business.Features.PostLikes.Queries.GetPostLikeById;

public class GetPostLikeByIdQueryValidator : AbstractValidator<GetPostLikeByIdQuery>
{
    public GetPostLikeByIdQueryValidator()
    {
        RuleFor(q => q.Id)
            .NotEmpty();
    }
}
