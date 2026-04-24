namespace InstaConnect.Common.Application.Features.Data.Abstractions;

public interface IUnitOfWork
{
    Task BeginAsync(CancellationToken cancellationToken);

    Task CommitAsync(CancellationToken cancellationToken);

    Task AbortAsync(CancellationToken cancellationToken);
}
