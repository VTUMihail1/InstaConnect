namespace InstaConnect.Shared.Business.Contracts.PostLikes;

public class PostLikeCreatedEvent
{
    public string Id { get; set; } = string.Empty;

    public string PostId { get; set; } = string.Empty;

    public string UserId { get; set; } = string.Empty;
}
