using InstaConnect.Posts.Business.Models.Post;
using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Posts.Business.Queries.Posts.GetPostById;

public record GetPostByIdQuery(string Id) : IQuery<PostQueryViewModel>;
