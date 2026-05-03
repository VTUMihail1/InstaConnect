using InstaConnect.Common.Infrastructure.Features.Seedings.Abstractions;

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Common.Presentation.Features.Seedings.Extensions;

public static class WebApplicationExtensions
{
	extension(WebApplication webApplication)
	{
		public async Task<WebApplication> UseDatabaseSeedingAsync(CancellationToken cancellationToken)
		{
			await webApplication
				.Services
				.CreateScope()
				.ServiceProvider
				.GetRequiredService<IDatabaseSeeder>()
				.SeedAsync(cancellationToken);

			return webApplication;
		}
	}
}
