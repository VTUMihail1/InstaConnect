namespace InstaConnect.Common.Infrastructure.Features.Seedings.Abstractions;

public interface IDatabaseSeeder
{
	public Task SeedAsync(CancellationToken cancellationToken);
}
