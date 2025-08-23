using InstaConnect.Common.Tests.Utilities.Builders;
using InstaConnect.Common.Tests.Utilities.DataAttributes.Strings.Base;
using InstaConnect.PostCommentLikes.Presentation.Features.PostCommentLikes.Models.Requests;
using InstaConnect.PostComments.Common.Tests.Features.PostComments.Utilities;
using InstaConnect.PostComments.Domain.Features.PostComments.Models.Entities;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities;
using InstaConnect.Posts.Common.Tests.Features.Users.Utilities;

namespace InstaConnect.PostCommentLikes.Common.Tests.Features.PostCommentLikes.Utilities.Builders.AddApiRequest;

public class AddPostCommentLikeApiRequestBuilder
{
    private readonly ObjectBuilder<AddPostCommentLikeApiRequest> _objectBuilder;

    public AddPostCommentLikeApiRequestBuilder(ObjectBuilder<AddPostCommentLikeApiRequest> objectBuilder, Post post, PostComment postComment, User user)
    {
        _objectBuilder = objectBuilder;

        WithId(post.Id);
        WithCommentId(postComment.Id);
        WithUserId(user.Id);
    }

    public AddPostCommentLikeApiRequestBuilder WithId(string id, IStringTransformer? transformer = null)
    {
        _objectBuilder.With(p => p.Id, id, transformer);

        return this;
    }

    public AddPostCommentLikeApiRequestBuilder WithCommentId(string commentId, IStringTransformer? transformer = null)
    {
        _objectBuilder.With(p => p.CommentId, commentId, transformer);

        return this;
    }

    public AddPostCommentLikeApiRequestBuilder WithUserId(string userId, IStringTransformer? transformer = null)
    {
        _objectBuilder.With(p => p.UserId, userId, transformer);

        return this;
    }

    public AddPostCommentLikeApiRequest Build()
    {
        return _objectBuilder.Build();
    }
}
