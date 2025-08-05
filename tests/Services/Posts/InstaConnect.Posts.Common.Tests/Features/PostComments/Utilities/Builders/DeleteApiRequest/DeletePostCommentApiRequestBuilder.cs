using InstaConnect.Common.Tests.Utilities.Builders;
using InstaConnect.Common.Tests.Utilities.DataAttributes.Strings.Base;
using InstaConnect.PostComments.Domain.Features.PostComments.Models.Entities;
using InstaConnect.PostComments.Presentation.Features.PostComments.Models.Requests;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities;
using InstaConnect.Posts.Common.Tests.Features.Users.Utilities;

namespace InstaConnect.PostComments.Common.Tests.Features.PostComments.Utilities.Builders.DeleteApiRequest;

public class DeletePostCommentApiRequestBuilder
{
    private readonly ObjectBuilder<DeletePostCommentApiRequest> _objectBuilder;

    public DeletePostCommentApiRequestBuilder(ObjectBuilder<DeletePostCommentApiRequest> objectBuilder)
    {
        _objectBuilder = objectBuilder;

        WithId(PostDataFaker.GetId());
        WithCommentId(PostCommentDataFaker.GetId());
        WithUserId(UserDataFaker.GetId());
    }

    public DeletePostCommentApiRequestBuilder(ObjectBuilder<DeletePostCommentApiRequest> objectBuilder, PostComment postComment)
    {
        _objectBuilder = objectBuilder;

        WithId(postComment.Id);
        WithCommentId(postComment.CommentId);
        WithUserId(postComment.UserId);
    }

    public DeletePostCommentApiRequestBuilder WithId(string id, IStringTransformer? transformer = null)
    {
        _objectBuilder.With(p => p.Id, id, transformer);

        return this;
    }

    public DeletePostCommentApiRequestBuilder WithCommentId(string commentId, IStringTransformer? transformer = null)
    {
        _objectBuilder.With(p => p.CommentId, commentId, transformer);

        return this;
    }

    public DeletePostCommentApiRequestBuilder WithUserId(string userId, IStringTransformer? transformer = null)
    {
        _objectBuilder.With(p => p.UserId, userId, transformer);

        return this;
    }

    public DeletePostCommentApiRequest Create()
    {
        return _objectBuilder.Create();
    }
}
