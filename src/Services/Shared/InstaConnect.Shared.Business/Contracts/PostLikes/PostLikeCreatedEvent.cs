namespace InstaConnect.Shared.Business.Contracts.PostLikes;

public class PostLikeCreatedEvent
{
    public string Id { get; set; }

    public string PostId { get; set; }

    public string UserId { get; set; }
}
