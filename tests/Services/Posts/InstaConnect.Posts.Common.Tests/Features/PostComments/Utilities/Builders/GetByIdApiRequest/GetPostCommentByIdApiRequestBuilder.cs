using InstaConnect.Common.Tests.Utilities.Builders;
using InstaConnect.Common.Tests.Utilities.DataAttributes.Strings.Base;
using InstaConnect.PostComments.Domain.Features.PostComments.Models.Entities;
using InstaConnect.PostComments.Presentation.Features.PostComments.Models.Requests;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities;

namespace InstaConnect.PostComments.Common.Tests.Features.PostComments.Utilities.Builders.GetByIdApiRequest;

public class GetPostCommentByIdApiRequestBuilder
{
    private readonly ObjectBuilder<GetPostCommentByIdApiRequest> _objectBuilder;

    public GetPostCommentByIdApiRequestBuilder(ObjectBuilder<GetPostCommentByIdApiRequest> objectBuilder)
    {
        _objectBuilder = objectBuilder;

        WithId(PostDataFaker.GetId());
        WithCommentId(PostCommentDataFaker.GetId());
    }

    public GetPostCommentByIdApiRequestBuilder(ObjectBuilder<GetPostCommentByIdApiRequest> objectBuilder, PostComment postComment)
    {
        _objectBuilder = objectBuilder;

        WithId(postComment.Id);
        WithCommentId(postComment.CommentId);
    }

    public GetPostCommentByIdApiRequestBuilder WithId(string id, IStringTransformer? transformer = null)
    {
        _objectBuilder.With(p => p.Id, id, transformer);

        return this;
    }

    public GetPostCommentByIdApiRequestBuilder WithCommentId(string commentId, IStringTransformer? transformer = null)
    {
        _objectBuilder.With(p => p.CommentId, commentId, transformer);

        return this;
    }

    public GetPostCommentByIdApiRequest Create()
    {
        return _objectBuilder.Create();
    }
}
