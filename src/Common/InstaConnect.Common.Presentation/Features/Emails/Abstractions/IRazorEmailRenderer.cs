namespace InstaConnect.Common.Presentation.Features.Emails.Abstractions;

public interface IRazorEmailRenderer
{
    Task<string> RenderAsync<TModel>(string templateKey, TModel model, CancellationToken cancellationToken);
}
