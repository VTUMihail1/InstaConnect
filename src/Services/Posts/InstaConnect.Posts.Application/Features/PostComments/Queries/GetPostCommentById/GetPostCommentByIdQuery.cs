using InstaConnect.Posts.Application.Features.PostComments.Models;
using InstaConnect.Shared.Application.Abstractions;

namespace InstaConnect.Posts.Application.Features.PostComments.Queries.GetPostCommentById;

public record GetPostCommentByIdQuery(string Id) : IQuery<PostCommentQueryViewModel>;
