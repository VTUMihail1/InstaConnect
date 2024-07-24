namespace InstaConnect.Follows.Read.Business.Models;

public class FollowQueryViewModel
{
    public string Id { get; set; } = string.Empty;

    public string FollowerId { get; set; } = string.Empty;

    public string FollowerName { get; set; } = string.Empty;

    public string? FollowerProfileImage { get; set; } = string.Empty;

    public string FollowingId { get; set; } = string.Empty;

    public string FollowingName { get; set; } = string.Empty;

    public string? FollowingProfileImage { get; set; } = string.Empty;
}
