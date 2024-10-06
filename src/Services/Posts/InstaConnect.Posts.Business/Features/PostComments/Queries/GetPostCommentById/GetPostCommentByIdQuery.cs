using InstaConnect.Posts.Business.Features.PostComments.Models;
using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Posts.Business.Features.PostComments.Queries.GetPostCommentById;

public record GetPostCommentByIdQuery(string Id) : IQuery<PostCommentQueryViewModel>;
