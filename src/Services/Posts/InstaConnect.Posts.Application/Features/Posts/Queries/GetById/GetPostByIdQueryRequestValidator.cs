namespace InstaConnect.Posts.Application.Features.Posts.Queries.GetById;

public class GetPostByIdQueryRequestValidator : AbstractValidator<GetPostByIdQueryRequest>
{
    public GetPostByIdQueryRequestValidator()
    {
        RuleFor(r => r.Id)
            .NotEmpty()
            .WithMessage(PostErrorMessages.GetIdEmpty())
            .MinimumLength(PostConfigurations.IdMinLength)
            .WithMessage(r => PostErrorMessages.GetIdTooShort(r.Id.Length))
            .MaximumLength(PostConfigurations.IdMaxLength)
            .WithMessage(r => PostErrorMessages.GetIdTooLong(r.Id.Length));
    }
}
