using InstaConnect.Posts.Domain.Features.PostLikes.Helpers;

namespace InstaConnect.Posts.Domain.Features.PostLikes.Abstractions;

public interface IPostLikeIncludeQueryBuilderFactory
{
    PostLikeIncludeQueryBuilder Create();
}