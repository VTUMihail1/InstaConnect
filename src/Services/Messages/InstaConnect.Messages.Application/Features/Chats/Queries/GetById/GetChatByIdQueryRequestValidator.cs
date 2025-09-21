using InstaConnect.Chats.Common.Features.Chats.Utilities;
using InstaConnect.Posts.Common.Features.Users.Utilities;
using InstaConnect.Posts.Domain.Features.Users.Utilities;

namespace InstaConnect.Chats.Application.Features.Chats.Queries.GetById;

public class GetChatByIdQueryRequestValidator : AbstractValidator<GetChatByIdQueryRequest>
{
    public GetChatByIdQueryRequestValidator()
    {
        RuleFor(r => r.ParticipantOneId)
            .NotEmpty()
            .WithMessage(UserErrorMessages.GetIdEmpty())
            .MinimumLength(UserConfigurations.IdMinLength)
            .WithMessage(r => UserErrorMessages.GetIdTooShort(r.ParticipantOneId.Length))
            .MaximumLength(UserConfigurations.IdMaxLength)
            .WithMessage(r => UserErrorMessages.GetIdTooLong(r.ParticipantOneId.Length));

        RuleFor(r => r.ParticipantTwoId)
            .NotEmpty()
            .WithMessage(UserErrorMessages.GetIdEmpty())
            .MinimumLength(UserConfigurations.IdMinLength)
            .WithMessage(r => UserErrorMessages.GetIdTooShort(r.ParticipantTwoId.Length))
            .MaximumLength(UserConfigurations.IdMaxLength)
            .WithMessage(r => UserErrorMessages.GetIdTooLong(r.ParticipantOneId.Length));
    }
}
