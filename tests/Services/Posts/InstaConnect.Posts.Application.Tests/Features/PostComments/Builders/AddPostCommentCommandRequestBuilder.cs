using InstaConnect.Common.Tests.DataAttributes.Base;

namespace InstaConnect.Posts.Application.Tests.Features.PostComments.Builders;
public class AddPostCommentCommandRequestBuilder
{
    private string _id;
    private string _userId;
    private string _content;

    public AddPostCommentCommandRequestBuilder(Post post, User user)
    {
        _id = post.Id;
        _userId = user.Id;
        _content = PostCommentDataFaker.GetContent();
    }

    public AddPostCommentCommandRequestBuilder WithId(string id, IStringTransformer? transformer = null)
    {
        _id = transformer.TryTransform(id);

        return this;
    }

    public AddPostCommentCommandRequestBuilder WithUserId(string userId, IStringTransformer? transformer = null)
    {
        _userId = transformer.TryTransform(userId);

        return this;
    }

    public AddPostCommentCommandRequestBuilder WithContent(string content, IStringTransformer? transformer = null)
    {
        _content = transformer.TryTransform(content);

        return this;
    }

    public AddPostCommentCommandRequest Build()
    {
        return new(_id, _content, _userId);
    }
}
