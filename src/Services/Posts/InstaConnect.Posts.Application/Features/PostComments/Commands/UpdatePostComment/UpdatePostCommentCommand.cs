using InstaConnect.Posts.Business.Features.PostComments.Models;
using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Posts.Business.Features.PostComments.Commands.UpdatePostComment;

public record UpdatePostCommentCommand(string Id, string CurrentUserId, string Content) : ICommand<PostCommentCommandViewModel>;
