using InstaConnect.Common.Application.Models;

namespace InstaConnect.Identity.Application.Features.Users.Models;

public record UserFilterQueryRequest(
    string FirstName,
    string LastName,
    NamePayload Name);
