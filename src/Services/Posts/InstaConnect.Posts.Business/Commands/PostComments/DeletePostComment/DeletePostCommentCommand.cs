using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Posts.Business.Commands.PostComments.DeletePostComment;

public record DeletePostCommentCommand(string Id, string CurrentUserId) : ICommand;
