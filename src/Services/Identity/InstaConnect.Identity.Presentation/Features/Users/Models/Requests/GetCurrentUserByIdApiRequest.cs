using InstaConnect.Identity.Presentation.Features.Users.Abstractions;

namespace InstaConnect.Identity.Presentation.Features.Users.Models.Requests;

public record GetCurrentUserByIdApiRequest([UserIdFromClaim] string CurrentId) : ICurrentUserableApiRequest;
