using InstaConnect.Posts.Business.Models.PostCommentLike;
using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Posts.Business.Commands.PostCommentLikes.AddPostCommentLike;

public record AddPostCommentLikeCommand(string CurrentUserId, string PostCommentId) : ICommand<PostCommentLikeCommandViewModel>;
