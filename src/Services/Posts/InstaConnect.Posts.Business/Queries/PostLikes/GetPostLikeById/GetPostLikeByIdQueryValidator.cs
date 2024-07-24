using FluentValidation;

namespace InstaConnect.Posts.Read.Business.Queries.PostLikes.GetPostLikeById;

public class GetPostLikeByIdQueryValidator : AbstractValidator<GetPostLikeByIdQuery>
{
    public GetPostLikeByIdQueryValidator()
    {
        RuleFor(q => q.Id)
            .NotEmpty();
    }
}
