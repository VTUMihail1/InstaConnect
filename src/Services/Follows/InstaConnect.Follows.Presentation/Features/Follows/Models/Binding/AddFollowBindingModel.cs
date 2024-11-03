namespace InstaConnect.Follows.Web.Features.Follows.Models.Binding;

public class AddFollowBindingModel
{
    public AddFollowBindingModel(string followingId)
    {
        FollowingId = followingId;
    }

    public string FollowingId { get; set; }
}
