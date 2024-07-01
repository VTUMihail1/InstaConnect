using InstaConnect.Shared.Business.Contracts.Users;

namespace InstaConnect.Follows.Business.Write.Models;

public class FollowGetUserByIdModel
{
    public GetUserByIdRequest GetUserByFollowerIdRequest { get; set; } = new();

    public GetUserByIdRequest GetUserByFollowingIdRequest { get; set; } = new();
}
