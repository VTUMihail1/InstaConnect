namespace InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Models.Requests;

public record ForgotPasswordTokenInclude(ICollection<ForgotPasswordTokenIncludeProperty> Properties)
    : IInclude<ForgotPasswordTokenIncludeProperty>;
