using InstaConnect.Common.Infrastructure.Features.Data.Abstractions;

namespace InstaConnect.Posts.Infrastructure.Features.PostLikes.Abstractions;

internal interface IPostLikesForUserSortTermerFactory : ISortTermerFactory<PostLikesForUserSortTerm, IPostLikesForUserSortTermer, PostLikeResponse>;
