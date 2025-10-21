using InstaConnect.PostLikes.Domain.Features.PostLikes.Helpers;

namespace InstaConnect.PostLikes.Domain.Features.PostLikes.Abstractions;

public interface IPostLikeIncludeQueryBuilderFactory
{
    PostLikeIncludeQueryBuilder Create();
}