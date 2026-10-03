using InstaConnect.Common.Infrastructure.Features.Databases.Abstractions;

namespace InstaConnect.Follows.Infrastructure.Features.Follows.Abstractions;

public interface IFollowCollection : IMongoDbCollection<Follow>
{
	public IFollowFluent AggregateFluent();

	public Task UpdateAsync(
		Follow entity,
		CancellationToken cancellationToken);

	public Task DeleteAsync(
		Follow entity,
		CancellationToken cancellationToken);
}
