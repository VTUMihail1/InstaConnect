using InstaConnect.Common.Tests.Utilities.Builders;
using InstaConnect.Common.Tests.Utilities.DataAttributes.Strings.Base;
using InstaConnect.PostComments.Application.Features.PostComments.Commands.Delete;
using InstaConnect.PostComments.Domain.Features.PostComments.Models.Entities;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities;
using InstaConnect.Posts.Common.Tests.Features.Users.Utilities;

namespace InstaConnect.PostComments.Common.Tests.Features.PostComments.Utilities.Builders.DeleteCommandRequest;

public class DeletePostCommentCommandRequestBuilder
{
    private readonly ObjectBuilder<DeletePostCommentCommandRequest> _objectBuilder;

    public DeletePostCommentCommandRequestBuilder(ObjectBuilder<DeletePostCommentCommandRequest> objectBuilder)
    {
        _objectBuilder = objectBuilder;

        WithId(PostDataFaker.GetId());
        WithCommentId(PostCommentDataFaker.GetId());
        WithUserId(UserDataFaker.GetId());
    }

    public DeletePostCommentCommandRequestBuilder(ObjectBuilder<DeletePostCommentCommandRequest> objectBuilder, PostComment postComment)
    {
        _objectBuilder = objectBuilder;

        WithId(postComment.Id);
        WithCommentId(postComment.CommentId);
        WithUserId(postComment.UserId);
    }

    public DeletePostCommentCommandRequestBuilder WithId(string id, IStringTransformer? transformer = null)
    {
        _objectBuilder.With(p => p.Id, id, transformer);

        return this;
    }

    public DeletePostCommentCommandRequestBuilder WithCommentId(string commentId, IStringTransformer? transformer = null)
    {
        _objectBuilder.With(p => p.CommentId, commentId, transformer);

        return this;
    }

    public DeletePostCommentCommandRequestBuilder WithUserId(string userId, IStringTransformer? transformer = null)
    {
        _objectBuilder.With(p => p.UserId, userId, transformer);

        return this;
    }

    public DeletePostCommentCommandRequest Create()
    {
        return _objectBuilder.Create();
    }
}
