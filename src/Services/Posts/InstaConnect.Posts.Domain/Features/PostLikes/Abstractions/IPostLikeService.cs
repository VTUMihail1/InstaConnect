using InstaConnect.Common.Domain.Models.Pagination;
using InstaConnect.Posts.Domain.Features.PostComments.Models.Entities;
using InstaConnect.Posts.Domain.Features.PostComments.Models.Filters;
using InstaConnect.Posts.Domain.Features.PostLikes.Models.Entities;
using InstaConnect.Posts.Domain.Features.PostLikes.Models.Filters;
using InstaConnect.Posts.Domain.Features.Posts.Models.Entities;

namespace InstaConnect.Posts.Domain.Features.PostComments.Abstractions;
public interface IPostLikeService
{
    public Task<PaginationList<PostLike>> GetAllAsync(Post post, PostLikeCollectionReadQuery query, CancellationToken cancellationToken);

    public Task<PostLike> GetByIdAsync(Post post, string id, CancellationToken cancellationToken);

    public Task<PostLike> AddAsync(Post post, string userId, CancellationToken cancellationToken);

    public Task DeleteAsync(Post post, string id, string userId, CancellationToken cancellationToken);

}
