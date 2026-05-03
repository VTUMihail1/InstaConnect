using InstaConnect.Common.Presentation.Features.Emails.Abstractions;
using InstaConnect.Identity.Presentation.Features.EmailConfirmationTokens.Abstractions;

namespace InstaConnect.Identity.Presentation.Features.EmailConfirmationTokens.Helpers;

internal class EmailConfirmationTokenTemplateFactory : IEmailConfirmationTokenTemplateFactory
{
	private readonly IRazorEmailRenderer _renderer;

	public EmailConfirmationTokenTemplateFactory(IRazorEmailRenderer renderer)
	{
		_renderer = renderer;
	}

	public async Task<string> GetAddedAsync(EmailConfirmationTokenAddedViewRequest request, CancellationToken cancellationToken)
	{
		const string TemplateKey = "Features.EmailConfirmationTokens.Templates.Added";

		return await _renderer.RenderAsync(TemplateKey, request, cancellationToken);
	}
}
