namespace InstaConnect.Identity.Presentation.Features.EmailConfirmationTokens.Models.Payloads;

public record EmailConfirmationTokenIdApiPayload(UserIdApiPayload Id, string Value);
