namespace InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Extensions;

internal static class ServiceCollectionExtensions
{
	extension(IServiceCollection serviceCollection)
	{
		public IServiceCollection AddForgotPasswordTokenServices()
		{
			return serviceCollection;
		}
	}
}
