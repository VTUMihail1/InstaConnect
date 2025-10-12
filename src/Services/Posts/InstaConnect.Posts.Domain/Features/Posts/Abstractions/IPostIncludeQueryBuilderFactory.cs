using InstaConnect.Posts.Domain.Features.Posts.Helpers;

namespace InstaConnect.Posts.Domain.Features.Posts.Abstractions;

public interface IPostIncludeQueryBuilderFactory
{
    PostIncludeQueryBuilder Create();
}