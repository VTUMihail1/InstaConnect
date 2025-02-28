using InstaConnect.Common.Domain.Models.Pagination;
using InstaConnect.Messages.Domain.Features.Messages.Models.Entities;
using InstaConnect.Messages.Domain.Features.Messages.Models.Filters;

namespace InstaConnect.Messages.Domain.Features.Messages.Abstractions;
public interface IMessageReadRepository
{
    Task<PaginationList<Message>> GetAllAsync(MessageCollectionReadQuery query, CancellationToken cancellationToken);
    Task<Message?> GetByIdAsync(string id, CancellationToken cancellationToken);
}
