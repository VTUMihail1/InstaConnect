using InstaConnect.Posts.Business.Models.PostComment;
using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Posts.Business.Commands.PostComments.UpdatePostComment;

public record UpdatePostCommentCommand(string Id, string CurrentUserId, string Content) : ICommand<PostCommentCommandViewModel>;
