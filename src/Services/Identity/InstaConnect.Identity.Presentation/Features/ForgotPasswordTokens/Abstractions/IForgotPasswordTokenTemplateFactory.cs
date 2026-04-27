namespace InstaConnect.Identity.Presentation.Features.ForgotPasswordTokens.Abstractions;

public interface IForgotPasswordTokenTemplateFactory
{
    Task<string> GetAddedAsync(ForgotPasswordTokenAddedViewRequest request, CancellationToken cancellationToken);
}
