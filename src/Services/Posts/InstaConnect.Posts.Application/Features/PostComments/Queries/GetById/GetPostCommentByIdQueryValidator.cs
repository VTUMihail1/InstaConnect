using FluentValidation;

using InstaConnect.Posts.Common.Features.PostComments.Utilities;

namespace InstaConnect.Posts.Application.Features.PostComments.Queries.GetById;

public class GetPostCommentByIdQueryValidator : AbstractValidator<GetPostCommentByIdQuery>
{
    public GetPostCommentByIdQueryValidator()
    {
        RuleFor(q => q.Id)
            .NotEmpty()
            .MinimumLength(PostCommentConfigurations.IdMinLength)
            .MaximumLength(PostCommentConfigurations.IdMaxLength);
        ;
    }
}
