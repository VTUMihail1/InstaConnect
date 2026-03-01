using InstaConnect.Identity.Events.Features.Users;

namespace InstaConnect.Identity.Events.Features.EmailConfirmationTokens;

public record EmailConfirmationTokenAddedEventRequest(EmailConfirmationTokenEventRequest EmailConfirmationToken) : IEventRequest;
