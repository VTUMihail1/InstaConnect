namespace InstaConnect.Follows.Domain.Features.Follows.Models.Requests;

public record GetFollowByIdQuery(
    FollowId Id,
    CurrentUserQuery CurrentUser) : ICurrentUserableQuery;
