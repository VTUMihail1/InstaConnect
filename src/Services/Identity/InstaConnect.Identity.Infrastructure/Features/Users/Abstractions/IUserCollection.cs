using InstaConnect.Common.Infrastructure.Features.Databases.Abstractions;

namespace InstaConnect.Identity.Infrastructure.Features.Users.Abstractions;

public interface IUserCollection : IMongoDbCollection<User>
{
	public IUserFluent AggregateFluent();

	public Task UpdateAsync(
		User entity,
		CancellationToken cancellationToken);

	public Task DeleteAsync(
		User entity,
		CancellationToken cancellationToken);
}
