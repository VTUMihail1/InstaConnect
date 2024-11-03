using InstaConnect.Posts.Business.Features.PostComments.Models;
using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Posts.Business.Features.PostComments.Commands.AddPostComment;

public record AddPostCommentCommand(string CurrentUserId, string PostId, string Content) : ICommand<PostCommentCommandViewModel>;
