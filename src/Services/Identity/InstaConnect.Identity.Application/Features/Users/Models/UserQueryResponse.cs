using InstaConnect.Common.Application.Models;

namespace InstaConnect.Identity.Application.Features.Users.Models;

public record UserQueryResponse(
    UserIdPayload Id,
    string FirstName,
    string LastName,
    NamePayload Name,
    ImagePayload? ProfileImage,
    DateTimeOffset CreatedAtUtc,
    DateTimeOffset UpdatedAtUtc);
