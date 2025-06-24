using InstaConnect.Posts.Application.Features.Posts.Commands.Add;

namespace InstaConnect.Posts.Application.Features.Posts.Commands.Update;

public record UpdatePostRequest(string Id, string CurrentUserId, string Title, string Content);
