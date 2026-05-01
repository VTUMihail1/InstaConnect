namespace InstaConnect.Common.Presentation.Features.Emails.Abstractions;

public interface IRazorEmailRenderer
{
	public Task<string> RenderAsync<TModel>(string templateKey, TModel model, CancellationToken cancellationToken);
}
