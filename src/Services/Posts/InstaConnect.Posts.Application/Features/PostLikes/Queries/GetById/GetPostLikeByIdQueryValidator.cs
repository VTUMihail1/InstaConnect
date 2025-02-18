namespace InstaConnect.Posts.Application.Features.PostLikes.Queries.GetById;

public class GetPostLikeByIdQueryValidator : AbstractValidator<GetPostLikeByIdQuery>
{
    public GetPostLikeByIdQueryValidator()
    {
        RuleFor(q => q.Id)
            .NotEmpty()
            .MinimumLength(PostLikeBusinessConfigurations.IdMinLength)
            .MaximumLength(PostLikeBusinessConfigurations.IdMaxLength);
    }
}
