using InstaConnect.Common.Presentation.Features.Emails.Abstractions;

using RazorLight;

namespace InstaConnect.Common.Presentation.Features.Emails.Helpers;

internal class RazorEmailRenderer : IRazorEmailRenderer
{
	private readonly IRazorLightEngine _engine;

	public RazorEmailRenderer(IRazorLightEngine engine)
	{
		_engine = engine;
	}

	public Task<string> RenderAsync<TModel>(string templateKey, TModel model, CancellationToken cancellationToken)
	{
		return _engine.CompileRenderAsync(templateKey, model);
	}
}
