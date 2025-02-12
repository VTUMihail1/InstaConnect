using InstaConnect.Messages.Domain.Features.Messages.Models.Entities;

namespace InstaConnect.Messages.Domain.Features.Messages.Abstractions;
public interface IMessageWriteRepository
{
    void Add(Message message);
    Task<bool> AnyAsync(CancellationToken cancellationToken);
    void Delete(Message message);
    Task<Message?> GetByIdAsync(string id, CancellationToken cancellationToken);
    void Update(Message message);
}
