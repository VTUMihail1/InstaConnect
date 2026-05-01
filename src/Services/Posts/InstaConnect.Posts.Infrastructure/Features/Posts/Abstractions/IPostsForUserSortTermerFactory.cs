using InstaConnect.Common.Infrastructure.Features.Data.Abstractions;

namespace InstaConnect.Posts.Infrastructure.Features.Posts.Abstractions;

internal interface IPostsForUserSortTermerFactory : ISortTermerFactory<PostsForUserSortTerm, IPostsForUserSortTermer, PostResponse>;
