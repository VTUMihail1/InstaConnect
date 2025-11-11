namespace InstaConnect.Posts.Presentation.Tests.Features.PostComments.Builders;

public class AddPostCommentApiRequestBuilder
{
    private string _id;
    private string _userId;
    private string _content;

    public AddPostCommentApiRequestBuilder(Post post, User user)
    {
        _id = post.Id;
        _userId = user.Id;
        _content = PostCommentDataFaker.GetContent();
    }

    public AddPostCommentApiRequestBuilder WithId(string id, IStringTransformer? transformer = null)
    {
        _id = transformer.TryTransform(id);

        return this;
    }

    public AddPostCommentApiRequestBuilder WithUserId(string userId, IStringTransformer? transformer = null)
    {
        _userId = transformer.TryTransform(userId);

        return this;
    }

    public AddPostCommentApiRequestBuilder WithContent(string content, IStringTransformer? transformer = null)
    {
        _content = transformer.TryTransform(content);

        return this;
    }

    public AddPostCommentApiRequest Build()
    {
        return new(_id, _userId, new(_content));
    }
}
