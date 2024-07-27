using InstaConnect.Posts.Business.Models.PostComment;
using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Posts.Business.Queries.PostComments.GetPostCommentById;

public record GetPostCommentByIdQuery(string Id) : IQuery<PostCommentQueryViewModel>;
