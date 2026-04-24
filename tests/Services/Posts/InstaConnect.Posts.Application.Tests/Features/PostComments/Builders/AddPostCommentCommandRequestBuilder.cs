namespace InstaConnect.Posts.Application.Tests.Features.PostComments.Builders;

public class AddPostCommentCommandRequestBuilder
{
    private string _id;
    private string _userId;
    private string _content;

    public AddPostCommentCommandRequestBuilder(Post post, User user)
    {
        _id = post.Id.Id;
        _userId = user.Id.Id;
        _content = PostCommentDataFaker.GetContent();
    }

    public AddPostCommentCommandRequestBuilder WithId(PostId id, IStringTransformer? transformer = null)
    {
        _id = transformer.TryTransform(id.Id);

        return this;
    }

    public AddPostCommentCommandRequestBuilder WithId(IStringTransformer transformer)
    {
        _id = transformer.Transform(_id);

        return this;
    }

    public AddPostCommentCommandRequestBuilder WithUserId(UserId userId, IStringTransformer? transformer = null)
    {
        _userId = transformer.TryTransform(userId.Id);

        return this;
    }

    public AddPostCommentCommandRequestBuilder WithUserId(IStringTransformer transformer)
    {
        _userId = transformer.Transform(_userId);

        return this;
    }

    public AddPostCommentCommandRequestBuilder WithContent(IStringTransformer transformer)
    {
        _content = transformer.Transform(_content);

        return this;
    }

    public AddPostCommentCommandRequest Build()
    {
        return new(_id, _content, _userId);
    }
}
