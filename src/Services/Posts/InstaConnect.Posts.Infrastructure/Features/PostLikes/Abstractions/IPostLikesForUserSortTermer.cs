using InstaConnect.Common.Infrastructure.Features.Databases.Abstractions;

namespace InstaConnect.Posts.Infrastructure.Features.PostLikes.Abstractions;

internal interface IPostLikesForUserSortTermer : ISortTermer<PostLikesForUserSortTerm, PostLikeResponse>;
