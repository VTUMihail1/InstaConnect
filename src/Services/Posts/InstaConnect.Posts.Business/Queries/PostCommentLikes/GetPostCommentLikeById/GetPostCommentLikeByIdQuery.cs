using InstaConnect.Posts.Business.Models.PostCommentLike;
using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Posts.Business.Queries.PostCommentLikes.GetPostCommentLikeById;

public record GetPostCommentLikeByIdQuery(string Id) : IQuery<PostCommentLikeQueryViewModel>;
