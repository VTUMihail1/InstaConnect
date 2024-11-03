using InstaConnect.Posts.Business.Features.Posts.Models;
using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Posts.Business.Features.Posts.Queries.GetPostById;

public record GetPostByIdQuery(string Id) : IQuery<PostQueryViewModel>;
