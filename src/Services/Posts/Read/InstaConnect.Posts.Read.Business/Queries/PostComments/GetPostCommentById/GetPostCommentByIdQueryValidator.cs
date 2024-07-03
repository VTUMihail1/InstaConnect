using FluentValidation;

namespace InstaConnect.Posts.Read.Business.Queries.PostComments.GetPostCommentById;

public class GetPostCommentByIdQueryValidator : AbstractValidator<GetPostCommentByIdQuery>
{
    public GetPostCommentByIdQueryValidator()
    {
        RuleFor(q => q.Id)
            .NotEmpty();
    }
}
