using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Identity.Domain.Tests.Features.Users.Utilities;

public static class UserSetups
{
	extension(IServiceProvider serviceProvider)
	{
		public IUserCommandService GetUserCommandService()
		{
			return serviceProvider.GetRequiredService<IUserCommandService>();
		}

		public IUserQueryService GetUserQueryService()
		{
			return serviceProvider.GetRequiredService<IUserQueryService>();
		}
	}

	extension(IServiceScope serviceScope)
	{
		public IUserCommandService GetUserCommandService()
		{
			return serviceScope.ServiceProvider.GetUserCommandService();
		}

		public IUserQueryService GetUserQueryService()
		{
			return serviceScope.ServiceProvider.GetUserQueryService();
		}
	}
}
