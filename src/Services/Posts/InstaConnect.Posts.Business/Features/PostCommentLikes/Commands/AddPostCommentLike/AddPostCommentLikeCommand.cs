using InstaConnect.Posts.Business.Features.PostCommentLikes.Models;
using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Posts.Business.Features.PostCommentLikes.Commands.AddPostCommentLike;

public record AddPostCommentLikeCommand(string CurrentUserId, string PostCommentId) : ICommand<PostCommentLikeCommandViewModel>;
