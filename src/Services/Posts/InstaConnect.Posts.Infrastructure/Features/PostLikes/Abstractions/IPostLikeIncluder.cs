using InstaConnect.Common.Infrastructure.Features.Data.Abstractions;
using InstaConnect.Posts.Domain.Features.Common.Models.Requests;

namespace InstaConnect.Posts.Infrastructure.Features.PostLikes.Abstractions;

internal interface IPostLikeIncluder : IIncluder<PostLike, PostsIncludeType, PostsDestinationType>;
