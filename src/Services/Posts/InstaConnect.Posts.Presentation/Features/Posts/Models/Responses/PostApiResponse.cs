using InstaConnect.Posts.Presentation.Features.Users.Models.Responses;

namespace InstaConnect.Posts.Presentation.Features.Posts.Models.Responses;

public record PostApiResponse(
    PostIdApiPayload Id,
    string Title,
    string Content,
    UserApiResponse User,
    DateTimeOffset CreatedAtUtc,
    DateTimeOffset UpdatedAtUtc);
