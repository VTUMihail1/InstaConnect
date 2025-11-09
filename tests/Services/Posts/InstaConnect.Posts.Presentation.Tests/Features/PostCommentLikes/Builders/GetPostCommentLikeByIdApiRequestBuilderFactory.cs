namespace InstaConnect.Posts.Presentation.Tests.Features.PostCommentLikes.Builders;

public class GetPostCommentLikeByIdApiRequestBuilderFactory
{
    private readonly ObjectBuilderFactory<GetPostCommentLikeByIdApiRequest> _objectBuilderFactory = new();

    public GetPostCommentLikeByIdApiRequestBuilder Create(PostCommentLike postCommentLike)
    {
        var objectBuilder = _objectBuilderFactory.Create();
        var requestBuilder = new GetPostCommentLikeByIdApiRequestBuilder(objectBuilder, postCommentLike);

        return requestBuilder;
    }
}
