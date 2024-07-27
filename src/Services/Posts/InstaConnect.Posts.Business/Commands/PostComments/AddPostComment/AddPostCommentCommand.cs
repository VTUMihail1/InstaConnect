using InstaConnect.Posts.Business.Models.PostComment;
using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Posts.Business.Commands.PostComments.AddPostComment;

public record AddPostCommentCommand(string CurrentUserId, string PostId, string Content) : ICommand<PostCommentCommandViewModel>;
