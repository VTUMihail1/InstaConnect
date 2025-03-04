using InstaConnect.Common.Domain.Models.Pagination;
using InstaConnect.Posts.Domain.Features.PostComments.Models.Entities;
using InstaConnect.Posts.Domain.Features.PostComments.Models.Filters;
using InstaConnect.Posts.Domain.Features.Posts.Models.Entities;

namespace InstaConnect.Posts.Domain.Features.PostComments.Abstractions;
public interface IPostCommentService
{
    public Task<PaginationList<PostComment>> GetAllAsync(Post post, PostCommentCollectionReadQuery query, CancellationToken cancellationToken);

    public Task<PostComment> GetByIdAsync(Post post, string id, CancellationToken cancellationToken);

    public void Add(Post post, string content, string userId);

    public Task UpdateAsync(Post post, string id, string content, CancellationToken cancellationToken);

    public Task DeleteAsync(Post post, string id, CancellationToken cancellationToken);

}
