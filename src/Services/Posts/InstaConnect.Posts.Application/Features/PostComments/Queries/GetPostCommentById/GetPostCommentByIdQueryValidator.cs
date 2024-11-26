using FluentValidation;
using InstaConnect.Posts.Common.Features.PostComments.Utilities;

namespace InstaConnect.Posts.Application.Features.PostComments.Queries.GetPostCommentById;

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
