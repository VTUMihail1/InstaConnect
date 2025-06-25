namespace InstaConnect.Posts.Application.Features.Posts.Queries.GetById;

public class GetPostByIdQueryValidator : AbstractValidator<GetPostByIdQuery>
{
    public GetPostByIdQueryValidator()
    {
        RuleFor(c => c.Id)
            .NotEmpty()
            .WithMessage(PostErrorMessages.IdEmpty)
            .MinimumLength(PostConfigurations.IdMinLength)
            .WithMessage(PostErrorMessages.IdTooShort)
            .MaximumLength(PostConfigurations.IdMaxLength)
            .WithMessage(PostErrorMessages.IdTooLong);
    }
}
