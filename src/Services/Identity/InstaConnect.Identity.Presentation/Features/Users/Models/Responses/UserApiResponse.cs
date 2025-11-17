namespace InstaConnect.Identity.Presentation.Features.Users.Models.Responses;

public record UserApiResponse(
    UserIdApiPayload Id,
    string FirstName,
    string LastName,
    NameApiPayload Name,
    ImageApiPayload? ProfileImage,
    DateTimeOffset CreatedAtUtc,
    DateTimeOffset UpdatedAtUtc);
