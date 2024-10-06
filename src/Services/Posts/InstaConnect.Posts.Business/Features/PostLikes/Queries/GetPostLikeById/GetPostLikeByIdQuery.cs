using InstaConnect.Posts.Business.Features.PostLikes.Models;
using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Posts.Business.Features.PostLikes.Queries.GetPostLikeById;

public record GetPostLikeByIdQuery(string Id) : IQuery<PostLikeQueryViewModel>;
