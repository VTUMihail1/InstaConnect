namespace InstaConnect.Posts.Application.Tests.Features.PostCommentLikes.Builders;

public class GetAllPostCommentLikesQueryRequestBuilderFactory
{
    private readonly ObjectBuilderFactory<GetAllPostCommentLikesQueryRequest> _objectBuilderFactory = new();

    public GetAllPostCommentLikesQueryRequestBuilder Create(PostCommentLike postCommentLike, User user)
    {
        var objectBuilder = _objectBuilderFactory.Create();
        var requestBuilder = new GetAllPostCommentLikesQueryRequestBuilder(objectBuilder, postCommentLike, user);

        return requestBuilder;
    }
}
