using InstaConnect.Identity.Events.Features.Users;

namespace InstaConnect.Identity.Events.Features.ForgotPasswordTokens;

public record ForgotPasswordTokenAddedEventRequest(
    UserEventRequest User,
    ForgotPasswordTokenEventRequest ForgotPasswordToken)
    : IEventRequest;
