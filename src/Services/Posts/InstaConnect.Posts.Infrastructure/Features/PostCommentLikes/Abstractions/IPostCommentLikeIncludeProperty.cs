using InstaConnect.Common.Infrastructure.Abstractions;
using InstaConnect.PostCommentLikes.Domain.Features.PostCommentLikes.Models.Entities;
using InstaConnect.PostCommentLikes.Domain.Features.PostCommentLikes.Models.Requests;
using InstaConnect.Posts.Domain.Features.Posts.Models.Requests;

using MongoDB.Driver;

namespace InstaConnect.PostCommentLikes.Infrastructure.Features.PostCommentLikes.Abstractions;

public interface IPostCommentLikeIncludeProperty : IIncludeProperty<PostCommentLike>
{
    public PostCommentLikeIncludeProperty IncludeProperty { get; }
}
