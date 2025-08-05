using InstaConnect.Common.Tests.Utilities.Builders;
using InstaConnect.Common.Tests.Utilities.DataAttributes.Strings.Base;
using InstaConnect.PostComments.Application.Features.PostComments.Commands.Update;
using InstaConnect.PostComments.Common.Tests.Features.PostComments.Utilities.Builders.AddApiRequest;
using InstaConnect.PostComments.Domain.Features.PostComments.Models.Entities;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities;
using InstaConnect.Posts.Common.Tests.Features.Users.Utilities;

namespace InstaConnect.PostComments.Common.Tests.Features.PostComments.Utilities.Builders.UpdateCommandRequest;

public class UpdatePostCommentCommandRequestBuilder
{
    private readonly ObjectBuilder<UpdatePostCommentCommandRequest> _objectBuilder;

    public UpdatePostCommentCommandRequestBuilder(ObjectBuilder<UpdatePostCommentCommandRequest> objectBuilder)
    {
        _objectBuilder = objectBuilder;

        WithId(PostDataFaker.GetId());
        WithCommentId(PostCommentDataFaker.GetId());
        WithUserId(UserDataFaker.GetId());
        WithContent(PostCommentDataFaker.GetContent());
    }

    public UpdatePostCommentCommandRequestBuilder(ObjectBuilder<UpdatePostCommentCommandRequest> objectBuilder, PostComment postComment)
    {
        _objectBuilder = objectBuilder;

        WithId(postComment.Id);
        WithCommentId(postComment.CommentId);
        WithUserId(postComment.UserId);
        WithContent(PostCommentDataFaker.GetContent());
    }

    public UpdatePostCommentCommandRequestBuilder WithId(string id, IStringTransformer? transformer = null)
    {
        _objectBuilder.With(p => p.Id, id);

        return this;
    }

    public UpdatePostCommentCommandRequestBuilder WithCommentId(string commentId, IStringTransformer? transformer = null)
    {
        _objectBuilder.With(p => p.CommentId, commentId, transformer);

        return this;
    }

    public UpdatePostCommentCommandRequestBuilder WithUserId(string userId, IStringTransformer? transformer = null)
    {
        _objectBuilder.With(p => p.UserId, userId);

        return this;
    }

    public UpdatePostCommentCommandRequestBuilder WithContent(string content, IStringTransformer? transformer = null)
    {
        _objectBuilder.With(p => p.Content, content);

        return this;
    }

    public UpdatePostCommentCommandRequest Create()
    {
        return _objectBuilder.Create();
    }
}
