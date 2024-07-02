using FluentValidation;

namespace InstaConnect.Posts.Business.Read.Queries.PostLikes.GetPostLikeById;

public class GetPostLikeByIdQueryValidator : AbstractValidator<GetPostLikeByIdQuery>
{
    public GetPostLikeByIdQueryValidator()
    {
        RuleFor(q => q.Id)
            .NotEmpty();
    }
}
