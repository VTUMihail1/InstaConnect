using InstaConnect.Posts.Application.Features.Users.Models;

namespace InstaConnect.Posts.Application.Features.PostLikes.Commands.Add;

public record AddPostLikeCommandRequest(PostIdPayload Id, UserIdPayload UserId) : ICommandRequest<AddPostLikeCommandResponse>;
