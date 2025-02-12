using InstaConnect.Posts.Application.Features.PostLikes.Models;
using InstaConnect.Shared.Application.Abstractions;

namespace InstaConnect.Posts.Application.Features.PostLikes.Queries.GetById;

public record GetPostLikeByIdQuery(string Id) : IQuery<PostLikeQueryViewModel>;
