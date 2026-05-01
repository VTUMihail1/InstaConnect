using InstaConnect.Common.Presentation.Features.Emails.Abstractions;
using InstaConnect.Identity.Presentation.Features.ForgotPasswordTokens.Abstractions;

namespace InstaConnect.Identity.Presentation.Features.ForgotPasswordTokens.Helpers;

internal class ForgotPasswordTokenTemplateFactory : IForgotPasswordTokenTemplateFactory
{
	private readonly IRazorEmailRenderer _renderer;

	public ForgotPasswordTokenTemplateFactory(IRazorEmailRenderer renderer)
	{
		_renderer = renderer;
	}

	public async Task<string> GetAddedAsync(ForgotPasswordTokenAddedViewRequest request, CancellationToken cancellationToken)
	{
		const string TemplateKey = "Features.ForgotPasswordTokens.Views.Added";

		return await _renderer.RenderAsync(TemplateKey, request, cancellationToken);
	}
}
