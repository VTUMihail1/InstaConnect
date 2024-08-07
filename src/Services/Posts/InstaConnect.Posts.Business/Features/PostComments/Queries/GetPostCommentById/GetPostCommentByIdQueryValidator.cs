using FluentValidation;
using InstaConnect.Posts.Business.Features.PostComments.Utilities;

namespace InstaConnect.Posts.Business.Features.PostComments.Queries.GetPostCommentById;

public class GetPostCommentByIdQueryValidator : AbstractValidator<GetPostCommentByIdQuery>
{
    public GetPostCommentByIdQueryValidator()
    {
        RuleFor(q => q.Id)
            .NotEmpty()
            .MinimumLength(PostCommentBusinessConfigurations.ID_MIN_LENGTH)
            .MaximumLength(PostCommentBusinessConfigurations.ID_MAX_LENGTH);
        ;
    }
}
