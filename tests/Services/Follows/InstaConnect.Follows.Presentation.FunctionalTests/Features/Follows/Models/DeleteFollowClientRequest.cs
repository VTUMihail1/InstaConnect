using InstaConnect.Follows.Presentation.Features.Follows.Models.Requests;

namespace InstaConnect.Follows.Presentation.FunctionalTests.Features.Follows.Models;

public record DeleteFollowClientRequest(
    DeleteFollowRequest DeleteFollowRequest,
    bool IsAuthenticated = true);
