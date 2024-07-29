using FluentValidation;

namespace InstaConnect.Posts.Business.Features.PostComments.Queries.GetPostCommentById;

public class GetPostCommentByIdQueryValidator : AbstractValidator<GetPostCommentByIdQuery>
{
    public GetPostCommentByIdQueryValidator()
    {
        RuleFor(q => q.Id)
            .NotEmpty();
    }
}
