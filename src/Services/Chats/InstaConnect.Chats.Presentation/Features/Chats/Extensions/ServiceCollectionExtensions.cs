namespace InstaConnect.Chats.Presentation.Features.Chats.Extensions;

internal static class ServiceCollectionExtensions
{
	extension(IServiceCollection serviceCollection)
	{
		internal IServiceCollection AddChatServices()
		{
			return serviceCollection;
		}
	}
}
