using InstaConnect.Posts.Data.Features.PostCommentLikes.Models.Entitites;
using InstaConnect.Posts.Data.Features.PostCommentLikes.Models.Filters;
using InstaConnect.Shared.Data.Models.Pagination;

namespace InstaConnect.Posts.Data.Features.PostCommentLikes.Abstract;
public interface IPostCommentLikeReadRepository
{
    Task<PaginationList<PostCommentLike>> GetAllAsync(PostCommentLikeCollectionReadQuery query, CancellationToken cancellationToken);
    Task<PostCommentLike?> GetByIdAsync(string id, CancellationToken cancellationToken);
}
