using InstaConnect.Common.Infrastructure.Features.Data.Abstractions;

namespace InstaConnect.Posts.Infrastructure.Features.Posts.Abstractions;

internal interface IPostsSortTermerFactory : ISortTermerFactory<PostsSortTerm, IPostsSortTermer, PostResponse>;
