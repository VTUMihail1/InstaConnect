using InstaConnect.Common.Domain.Models.Pagination;
using InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.Entities;
using InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.Filters;

namespace InstaConnect.Posts.Domain.Features.PostCommentLikes.Abstractions;
public interface IPostCommentLikeReadRepository
{
    Task<PaginationList<PostCommentLike>> GetAllAsync(PostCommentLikeCollectionReadQuery query, CancellationToken cancellationToken);
    Task<PostCommentLike?> GetByIdAsync(string id, CancellationToken cancellationToken);
}
