using InstaConnect.Common.Infrastructure.Features.Databases.Abstractions;

namespace InstaConnect.Posts.Infrastructure.Features.Posts.Abstractions;

public interface IPostsSortTermerFactory : ISortTermerFactory<PostsSortTerm, IPostsSortTermer, PostResponse>;
