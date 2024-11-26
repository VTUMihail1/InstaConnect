using InstaConnect.Posts.Application.Features.PostCommentLikes.Models;
using InstaConnect.Shared.Application.Abstractions;

namespace InstaConnect.Posts.Application.Features.PostCommentLikes.Queries.GetPostCommentLikeById;

public record GetPostCommentLikeByIdQuery(string Id) : IQuery<PostCommentLikeQueryViewModel>;
