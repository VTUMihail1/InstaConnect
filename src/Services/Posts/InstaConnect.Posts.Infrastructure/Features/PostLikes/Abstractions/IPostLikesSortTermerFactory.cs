using InstaConnect.Common.Infrastructure.Features.Databases.Abstractions;

namespace InstaConnect.Posts.Infrastructure.Features.PostLikes.Abstractions;

public interface IPostLikesSortTermerFactory : ISortTermerFactory<PostLikesSortTerm, IPostLikesSortTermer, PostLikeResponse>;
