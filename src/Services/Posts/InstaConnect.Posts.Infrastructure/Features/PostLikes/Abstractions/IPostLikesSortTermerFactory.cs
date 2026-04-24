using InstaConnect.Common.Infrastructure.Features.Data.Abstractions;

namespace InstaConnect.Posts.Infrastructure.Features.PostLikes.Abstractions;

internal interface IPostLikesSortTermerFactory : ISortTermerFactory<PostLikesSortTerm, IPostLikesSortTermer, PostLikeResponse>;
