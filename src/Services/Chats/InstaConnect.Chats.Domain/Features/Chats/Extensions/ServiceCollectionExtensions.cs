namespace InstaConnect.Chats.Domain.Features.Chats.Extensions;

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
