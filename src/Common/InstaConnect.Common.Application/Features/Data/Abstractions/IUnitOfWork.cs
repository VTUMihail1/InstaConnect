namespace InstaConnect.Common.Application.Features.Data.Abstractions;

public interface IUnitOfWork
{
	public Task BeginAsync(CancellationToken cancellationToken);

	public Task CommitAsync(CancellationToken cancellationToken);

	public Task AbortAsync(CancellationToken cancellationToken);
}
