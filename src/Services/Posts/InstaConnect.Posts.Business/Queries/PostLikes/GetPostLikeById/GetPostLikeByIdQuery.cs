using InstaConnect.Posts.Business.Models.PostLike;
using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Posts.Business.Queries.PostLikes.GetPostLikeById;

public record GetPostLikeByIdQuery(string Id) : IQuery<PostLikeQueryViewModel>;
