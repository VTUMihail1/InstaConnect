namespace InstaConnect.Posts.Presentation.Tests.Features.PostComments.Builders;

public class GetAllPostCommentsApiRequestBuilderFactory
{
    public GetAllPostCommentsApiRequestBuilder Create(PostComment postComment, User user)
    {
        return new(postComment, user);
    }
}
