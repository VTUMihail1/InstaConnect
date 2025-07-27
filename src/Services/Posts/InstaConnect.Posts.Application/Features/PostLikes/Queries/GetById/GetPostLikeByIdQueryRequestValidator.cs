namespace InstaConnect.Posts.Application.Features.PostLikes.Queries.GetById;

public class GetPostLikeByIdQueryRequestValidator : AbstractValidator<GetPostLikeByIdQueryRequest>
{
    public GetPostLikeByIdQueryRequestValidator()
    {
        RuleFor(q => q.Id)
            .NotEmpty()
            .MinimumLength(PostLikeConfigurations.IdMinLength)
            .MaximumLength(PostLikeConfigurations.IdMaxLength);
    }
}
