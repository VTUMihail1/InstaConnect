using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Posts.Business.Features.PostComments.Commands.DeletePostComment;

public record DeletePostCommentCommand(string Id, string CurrentUserId) : ICommand;
