namespace InstaConnect.Posts.Application.Features.PostLikes.Queries.GetById;

public class GetPostLikeByIdQueryValidator : AbstractValidator<GetPostLikeByIdQuery>
{
    public GetPostLikeByIdQueryValidator()
    {
        RuleFor(q => q.Id)
            .NotEmpty()
            .MinimumLength(PostLikeConfigurations.IdMinLength)
            .MaximumLength(PostLikeConfigurations.IdMaxLength);
    }
}
