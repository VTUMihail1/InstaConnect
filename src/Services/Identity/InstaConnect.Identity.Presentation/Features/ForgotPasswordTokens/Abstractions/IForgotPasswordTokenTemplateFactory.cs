namespace InstaConnect.Identity.Presentation.Features.ForgotPasswordTokens.Abstractions;

public interface IForgotPasswordTokenTemplateFactory
{
	public Task<string> GetAddedAsync(ForgotPasswordTokenAddedViewRequest request, CancellationToken cancellationToken);
}
