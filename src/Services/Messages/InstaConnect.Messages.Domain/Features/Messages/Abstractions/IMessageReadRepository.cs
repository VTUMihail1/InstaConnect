using InstaConnect.Messages.Domain.Features.Messages.Models.Entities;
using InstaConnect.Messages.Domain.Features.Messages.Models.Filters;
using InstaConnect.Shared.Domain.Models.Pagination;

namespace InstaConnect.Messages.Domain.Features.Messages.Abstractions;
public interface IMessageReadRepository
{
    Task<PaginationList<Message>> GetAllAsync(MessageCollectionReadQuery query, CancellationToken cancellationToken);
    Task<Message?> GetByIdAsync(string id, CancellationToken cancellationToken);
}
