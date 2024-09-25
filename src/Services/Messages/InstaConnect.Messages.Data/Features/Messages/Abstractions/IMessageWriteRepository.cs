using InstaConnect.Messages.Data.Features.Messages.Models.Entities;

namespace InstaConnect.Messages.Data.Features.Messages.Abstractions;
public interface IMessageWriteRepository
{
    void Add(Message message);
    Task<bool> AnyAsync(CancellationToken cancellationToken);
    void Delete(Message message);
    Task<Message?> GetByIdAsync(string id, CancellationToken cancellationToken);
    void Update(Message message);
}
