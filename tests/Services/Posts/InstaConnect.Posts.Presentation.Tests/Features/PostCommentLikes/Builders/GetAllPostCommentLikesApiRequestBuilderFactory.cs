namespace InstaConnect.Posts.Presentation.Tests.Features.PostCommentLikes.Builders;

public class GetAllPostCommentLikesApiRequestBuilderFactory
{
    private readonly ObjectBuilderFactory<GetAllPostCommentLikesApiRequest> _objectBuilderFactory = new();

    public GetAllPostCommentLikesApiRequestBuilder Create(PostCommentLike postCommentLike, User user)
    {
        var objectBuilder = _objectBuilderFactory.Create();
        var requestBuilder = new GetAllPostCommentLikesApiRequestBuilder(objectBuilder, postCommentLike, user);

        return requestBuilder;
    }
}
