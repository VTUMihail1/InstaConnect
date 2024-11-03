using InstaConnect.Posts.Business.Features.PostCommentLikes.Models;
using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Posts.Business.Features.PostCommentLikes.Queries.GetPostCommentLikeById;

public record GetPostCommentLikeByIdQuery(string Id) : IQuery<PostCommentLikeQueryViewModel>;
