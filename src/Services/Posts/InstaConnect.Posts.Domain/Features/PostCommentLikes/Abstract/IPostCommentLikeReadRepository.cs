using InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.Entitites;
using InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.Filters;
using InstaConnect.Shared.Domain.Models.Pagination;

namespace InstaConnect.Posts.Domain.Features.PostCommentLikes.Abstract;
public interface IPostCommentLikeReadRepository
{
    Task<PaginationList<PostCommentLike>> GetAllAsync(PostCommentLikeCollectionReadQuery query, CancellationToken cancellationToken);
    Task<PostCommentLike?> GetByIdAsync(string id, CancellationToken cancellationToken);
}
