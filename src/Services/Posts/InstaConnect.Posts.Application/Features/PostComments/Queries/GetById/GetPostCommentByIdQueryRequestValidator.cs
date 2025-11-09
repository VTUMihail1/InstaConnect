namespace InstaConnect.Posts.Application.Features.PostComments.Queries.GetById;

public class GetPostCommentByIdQueryRequestValidator : AbstractValidator<GetPostCommentByIdQueryRequest>
{
    public GetPostCommentByIdQueryRequestValidator()
    {
        RuleFor(c => c.Id)
            .NotEmpty()
            .WithMessage(PostErrorMessages.GetIdEmpty())
            .MinimumLength(PostConfigurations.IdMinLength)
            .WithMessage(r => PostErrorMessages.GetIdTooShort(r.Id.Length))
            .MaximumLength(PostConfigurations.IdMaxLength)
            .WithMessage(r => PostErrorMessages.GetIdTooLong(r.Id.Length));

        RuleFor(c => c.CommentId)
            .NotEmpty()
            .WithMessage(PostCommentErrorMessages.GetIdEmpty())
            .MinimumLength(PostCommentConfigurations.IdMinLength)
            .WithMessage(r => PostCommentErrorMessages.GetIdTooShort(r.CommentId.Length))
            .MaximumLength(PostCommentConfigurations.IdMaxLength)
            .WithMessage(r => PostCommentErrorMessages.GetIdTooLong(r.CommentId.Length));
    }
}
