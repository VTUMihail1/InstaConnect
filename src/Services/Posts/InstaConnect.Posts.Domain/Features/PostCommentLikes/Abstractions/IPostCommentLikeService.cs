using InstaConnect.Common.Domain.Models.Pagination;
using InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.Entities;
using InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.Filters;
using InstaConnect.Posts.Domain.Features.PostComments.Models.Entities;
using InstaConnect.Posts.Domain.Features.PostComments.Models.Filters;
using InstaConnect.Posts.Domain.Features.PostLikes.Models.Entities;
using InstaConnect.Posts.Domain.Features.PostLikes.Models.Filters;
using InstaConnect.Posts.Domain.Features.Posts.Models.Entities;

namespace InstaConnect.Posts.Domain.Features.PostComments.Abstractions;
public interface IPostCommentLikeService
{
    public Task<PaginationList<PostCommentLike>> GetAllAsync(
        Post post,
        string postCommentId,
        PostCommentLikeCollectionReadQuery query,
        CancellationToken cancellationToken);

    public Task<PostCommentLike> GetByIdAsync(Post post, string postCommentId, string id, CancellationToken cancellationToken);

    public Task AddAsync(Post post, string postCommentId, string userId, CancellationToken cancellationToken);

    public Task DeleteAsync(Post post, string postCommentId, string id, CancellationToken cancellationToken);

}
