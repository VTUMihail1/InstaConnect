using InstaConnect.Shared.Application.Abstractions;

namespace InstaConnect.Posts.Application.Features.PostComments.Commands.DeletePostComment;

public record DeletePostCommentCommand(string Id, string CurrentUserId) : ICommand;
