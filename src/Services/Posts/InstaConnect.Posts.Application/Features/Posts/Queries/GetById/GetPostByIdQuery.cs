using InstaConnect.Posts.Application.Features.Posts.Models;
using InstaConnect.Shared.Application.Abstractions;

namespace InstaConnect.Posts.Application.Features.Posts.Queries.GetById;

public record GetPostByIdQuery(string Id) : IQuery<PostQueryViewModel>;
