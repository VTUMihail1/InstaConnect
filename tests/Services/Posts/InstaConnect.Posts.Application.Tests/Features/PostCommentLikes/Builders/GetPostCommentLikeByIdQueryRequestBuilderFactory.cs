namespace InstaConnect.Posts.Application.Tests.Features.PostCommentLikes.Builders;

public class GetPostCommentLikeByIdQueryRequestBuilderFactory
{
    private readonly ObjectBuilderFactory<GetPostCommentLikeByIdQueryRequest> _objectBuilderFactory = new();

    public GetPostCommentLikeByIdQueryRequestBuilder Create(PostCommentLike postCommentLike)
    {
        var objectBuilder = _objectBuilderFactory.Create();
        var requestBuilder = new GetPostCommentLikeByIdQueryRequestBuilder(objectBuilder, postCommentLike);

        return requestBuilder;
    }
}
