using InstaConnect.Common.Infrastructure.Abstractions;
using InstaConnect.PostLikes.Domain.Features.PostLikes.Models.Entities;
using InstaConnect.PostLikes.Domain.Features.PostLikes.Models.Requests;
using InstaConnect.Posts.Domain.Features.Posts.Models.Requests;

using MongoDB.Driver;

namespace InstaConnect.PostLikes.Infrastructure.Features.PostLikes.Abstractions;

public interface IPostLikeIncludeProperty : IIncludeProperty<PostLike>
{
    public PostLikeIncludeProperty IncludeProperty { get; }
}
