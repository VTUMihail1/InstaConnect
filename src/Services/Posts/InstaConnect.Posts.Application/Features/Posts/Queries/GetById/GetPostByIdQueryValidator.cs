namespace InstaConnect.Posts.Application.Features.Posts.Queries.GetById;

public class GetPostByIdQueryValidator : AbstractValidator<GetPostByIdQuery>
{
    public GetPostByIdQueryValidator()
    {
        RuleFor(q => q.Id)
            .NotEmpty()
            .MinimumLength(PostConfigurations.IdMinLength)
            .MaximumLength(PostConfigurations.IdMaxLength);
    }
}
