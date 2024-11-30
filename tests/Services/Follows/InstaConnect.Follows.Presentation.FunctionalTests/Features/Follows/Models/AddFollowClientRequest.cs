using InstaConnect.Follows.Presentation.Features.Follows.Models.Requests;

namespace InstaConnect.Follows.Presentation.FunctionalTests.Features.Follows.Models;
public record AddFollowClientRequest(
    AddFollowRequest AddFollowRequest,
    bool IsAuthenticated = true);
