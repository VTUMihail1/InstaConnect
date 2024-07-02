using FluentValidation;

namespace InstaConnect.Posts.Business.Read.Queries.PostComments.GetPostCommentById;

public class GetPostCommentByIdQueryValidator : AbstractValidator<GetPostCommentByIdQuery>
{
    public GetPostCommentByIdQueryValidator()
    {
        RuleFor(q => q.Id)
            .NotEmpty();
    }
}
