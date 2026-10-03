namespace InstaConnect.Common.Infrastructure.Features.Seeders.Abstractions;

public interface IDatabaseSeeder
{
	public Task SeedAsync(CancellationToken cancellationToken);
}
