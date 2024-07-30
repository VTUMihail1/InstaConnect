using FluentValidation;
using InstaConnect.Follows.Business.Features.Follows.Utilities;

namespace InstaConnect.Posts.Business.Features.Posts.Queries.GetPostById;

public class GetPostByIdQueryValidator : AbstractValidator<GetPostByIdQuery>
{
    public GetPostByIdQueryValidator()
    {
        RuleFor(q => q.Id)
            .NotEmpty()
            .MinimumLength(PostBusinessConfigurations.ID_MIN_LENGTH)
            .MaximumLength(PostBusinessConfigurations.ID_MAX_LENGTH);
    }
}
