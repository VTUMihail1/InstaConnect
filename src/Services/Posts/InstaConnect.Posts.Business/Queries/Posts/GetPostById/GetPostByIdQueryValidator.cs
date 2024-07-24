using FluentValidation;

namespace InstaConnect.Posts.Read.Business.Queries.Posts.GetPostById;

public class GetPostByIdQueryValidator : AbstractValidator<GetPostByIdQuery>
{
    public GetPostByIdQueryValidator()
    {
        RuleFor(q => q.Id)
            .NotEmpty();
    }
}
