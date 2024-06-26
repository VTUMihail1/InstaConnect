namespace InstaConnect.Follows.Web.Read.Models.Responses;

public class FollowResponse
{
    public string Id { get; set; }

    public string FollowerId { get; set; }

    public string FollowerName { get; set; }

    public string FollowingId { get; set; }

    public string FollowingName { get; set; }
}
