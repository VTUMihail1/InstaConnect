namespace InstaConnect.Posts.Presentation.Tests.Features.PostComments.Builders;

public class AddPostCommentApiRequestBuilder
{
    private string _id;
    private string _userId;
    private string _content;

    public AddPostCommentApiRequestBuilder(Post post, User user)
    {
        _id = post.Id.Id;
        _userId = user.Id.Id;
        _content = PostCommentDataFaker.GetContent();
    }

    public AddPostCommentApiRequestBuilder WithId(Post post, IStringTransformer? transformer = null)
    {
        _id = transformer.TryTransform(post.Id.Id);

        return this;
    }

    public AddPostCommentApiRequestBuilder WithId(IStringTransformer transformer)
    {
        _id = transformer.Transform(_id);

        return this;
    }

    public AddPostCommentApiRequestBuilder WithUserId(User user, IStringTransformer? transformer = null)
    {
        _userId = transformer.TryTransform(user.Id.Id);

        return this;
    }

    public AddPostCommentApiRequestBuilder WithUserId(IStringTransformer transformer)
    {
        _userId = transformer.Transform(_userId);

        return this;
    }

    public AddPostCommentApiRequestBuilder WithContent(IStringTransformer transformer)
    {
        _content = transformer.Transform(_content);

        return this;
    }

    public AddPostCommentApiRequest Build()
    {
        return new(_id, _userId, new(_content));
    }
}
