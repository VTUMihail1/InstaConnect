using InstaConnect.Posts.Application.Features.Users.Models;

namespace InstaConnect.Posts.Application.Features.PostCommentLikes.Commands.Add;

public record AddPostCommentLikeCommandRequest(PostCommentIdPayload Id, UserIdPayload UserId) : ICommandRequest<AddPostCommentLikeCommandResponse>;
