using InstaConnect.Messages.Data.Features.Messages.Models.Entities;
using InstaConnect.Messages.Data.Features.Messages.Models.Filters;
using InstaConnect.Shared.Data.Models.Pagination;

namespace InstaConnect.Messages.Data.Features.Messages.Abstractions;
public interface IMessageReadRepository
{
    Task<PaginationList<Message>> GetAllAsync(MessageCollectionReadQuery query, CancellationToken cancellationToken);
    Task<Message?> GetByIdAsync(string id, CancellationToken cancellationToken);
}
