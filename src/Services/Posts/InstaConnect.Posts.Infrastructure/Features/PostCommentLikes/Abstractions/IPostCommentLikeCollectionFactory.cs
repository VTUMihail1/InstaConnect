using InstaConnect.PostCommentLikes.Domain.Features.PostCommentLikes.Models.Entities;
using InstaConnect.PostCommentLikes.Domain.Features.PostCommentLikes.Models.Requests;
using InstaConnect.PostCommentLikes.Domain.Features.PostCommentLikes.Models.Responses;

namespace InstaConnect.PostCommentLikes.Infrastructure.Features.PostCommentLikes.Abstractions;
internal interface IPostCommentLikeCollectionFactory
{
    PostCommentLikeCollection Create(ICollection<PostCommentLike> entities, int totalCount, PostCommentLikePaginationQuery pagination);
}
