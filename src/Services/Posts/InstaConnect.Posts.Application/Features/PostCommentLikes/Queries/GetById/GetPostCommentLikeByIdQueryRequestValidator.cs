namespace InstaConnect.Posts.Application.Features.PostCommentLikes.Queries.GetById;

public class GetPostCommentLikeByIdQueryRequestValidator : AbstractValidator<GetPostCommentLikeByIdQueryRequest>
{
    public GetPostCommentLikeByIdQueryRequestValidator()
    {
        RuleFor(r => r.Id)
            .NotEmpty()
            .WithMessage(PostErrorMessages.GetIdEmpty())
            .MinimumLength(PostConfigurations.IdMinLength)
            .WithMessage(r => PostErrorMessages.GetIdTooShort(r.Id.Length))
            .MaximumLength(PostConfigurations.IdMaxLength)
            .WithMessage(r => PostErrorMessages.GetIdTooLong(r.Id.Length));

        RuleFor(r => r.CommentId)
            .NotEmpty()
            .WithMessage(PostCommentErrorMessages.GetIdEmpty())
            .MinimumLength(PostCommentConfigurations.IdMinLength)
            .WithMessage(r => PostCommentErrorMessages.GetIdTooShort(r.CommentId.Length))
            .MaximumLength(PostCommentConfigurations.IdMaxLength)
            .WithMessage(r => PostCommentErrorMessages.GetIdTooLong(r.CommentId.Length));

        RuleFor(r => r.UserId)
            .NotEmpty()
            .WithMessage(UserErrorMessages.GetIdEmpty())
            .MinimumLength(UserConfigurations.IdMinLength)
            .WithMessage(r => UserErrorMessages.GetIdTooShort(r.UserId.Length))
            .MaximumLength(UserConfigurations.IdMaxLength)
            .WithMessage(r => UserErrorMessages.GetIdTooLong(r.UserId.Length));
    }
}
