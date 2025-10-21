using InstaConnect.PostCommentLikes.Domain.Features.PostCommentLikes.Models.Requests;
using InstaConnect.PostCommentLikes.Infrastructure.Features.PostCommentLikes.Abstractions;
using InstaConnect.Posts.Domain.Features.Posts.Models.Requests;

namespace InstaConnect.Common.Infrastructure.Abstractions;

public interface IPostCommentLikeIncludePropertyFactory
{
    ICollection<IPostCommentLikeIncludeProperty> Create(ICollection<PostCommentLikeIncludeProperty>? includeProperties);
}
