using InstaConnect.Posts.Application.Features.PostComments.Models;
using InstaConnect.Shared.Application.Abstractions;

namespace InstaConnect.Posts.Application.Features.PostComments.Commands.Update;

public record UpdatePostCommentCommand(string Id, string CurrentUserId, string Content) : ICommand<PostCommentCommandViewModel>;
