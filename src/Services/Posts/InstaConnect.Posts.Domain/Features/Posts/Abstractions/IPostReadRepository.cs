using InstaConnect.Common.Domain.Models.Pagination;
using InstaConnect.Posts.Domain.Features.Posts.Models;

namespace InstaConnect.Posts.Domain.Features.Posts.Abstractions;
public interface IPostReadRepository
{
    Task<PostQueryCollection> GetAllAsync(PostQueryParameters query, CancellationToken cancellationToken);
    Task<Post?> GetByIdAsync(string id, CancellationToken cancellationToken);
}
