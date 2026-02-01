namespace InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Models.Requests;

public record EmailConfirmationTokenInclude(ICollection<EmailConfirmationTokenIncludeProperty> Properties)
    : IInclude<EmailConfirmationTokenIncludeProperty>;
