using InstaConnect.Posts.Application.Features.PostCommentLikes.Models;
using InstaConnect.Shared.Application.Abstractions;

namespace InstaConnect.Posts.Application.Features.PostCommentLikes.Commands.AddPostCommentLike;

public record AddPostCommentLikeCommand(string CurrentUserId, string PostCommentId) : ICommand<PostCommentLikeCommandViewModel>;
