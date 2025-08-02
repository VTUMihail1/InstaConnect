using InstaConnect.PostCommentLikes.Common.Features.PostCommentLikes.Utilities;
using InstaConnect.PostComments.Common.Features.PostComments.Utilities;

namespace InstaConnect.PostCommentLikes.Application.Features.PostCommentLikes.Queries.GetById;

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

        RuleFor(r => r.CommentLikeId)
            .NotEmpty()
            .WithMessage(PostCommentLikeErrorMessages.GetIdEmpty())
            .MinimumLength(PostCommentLikeConfigurations.IdMinLength)
            .WithMessage(r => PostCommentLikeErrorMessages.GetIdTooShort(r.CommentLikeId.Length))
            .MaximumLength(PostCommentLikeConfigurations.IdMaxLength)
            .WithMessage(r => PostCommentLikeErrorMessages.GetIdTooLong(r.CommentLikeId.Length));
    }
}
