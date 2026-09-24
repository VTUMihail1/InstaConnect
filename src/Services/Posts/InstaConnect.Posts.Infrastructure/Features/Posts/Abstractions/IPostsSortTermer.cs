using InstaConnect.Common.Infrastructure.Features.Databases.Abstractions;

namespace InstaConnect.Posts.Infrastructure.Features.Posts.Abstractions;

internal interface IPostsSortTermer : ISortTermer<PostsSortTerm, PostResponse>;
