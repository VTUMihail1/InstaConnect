using InstaConnect.PostLikes.Common.Features.PostLikes.Utilities;

namespace InstaConnect.PostLikes.Application.Features.PostLikes.Queries.GetById;

public class GetPostLikeByIdQueryRequestValidator : AbstractValidator<GetPostLikeByIdQueryRequest>
{
    public GetPostLikeByIdQueryRequestValidator()
    {
        RuleFor(r => r.Id)
            .NotEmpty()
            .WithMessage(PostErrorMessages.GetIdEmpty())
            .MinimumLength(PostConfigurations.IdMinLength)
            .WithMessage(r => PostErrorMessages.GetIdTooShort(r.Id.Length))
            .MaximumLength(PostConfigurations.IdMaxLength)
            .WithMessage(r => PostErrorMessages.GetIdTooLong(r.Id.Length));

        RuleFor(r => r.LikeId)
            .NotEmpty()
            .WithMessage(PostLikeErrorMessages.GetIdEmpty())
            .MinimumLength(PostLikeConfigurations.IdMinLength)
            .WithMessage(r => PostLikeErrorMessages.GetIdTooShort(r.LikeId.Length))
            .MaximumLength(PostLikeConfigurations.IdMaxLength)
            .WithMessage(r => PostLikeErrorMessages.GetIdTooLong(r.LikeId.Length));
    }
}
