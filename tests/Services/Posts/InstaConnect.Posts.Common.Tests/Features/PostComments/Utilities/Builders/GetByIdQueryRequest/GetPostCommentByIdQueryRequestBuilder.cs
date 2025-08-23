using InstaConnect.Common.Tests.Utilities.Builders;
using InstaConnect.Common.Tests.Utilities.DataAttributes.Strings.Base;
using InstaConnect.PostComments.Application.Features.PostComments.Queries.GetById;
using InstaConnect.PostComments.Common.Tests.Features.PostComments.Utilities.Builders.AddApiRequest;
using InstaConnect.PostComments.Domain.Features.PostComments.Models.Entities;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities;

namespace InstaConnect.PostComments.Common.Tests.Features.PostComments.Utilities.Builders.GetByIdQueryRequest;

public class GetPostCommentByIdQueryRequestBuilder
{
    private readonly ObjectBuilder<GetPostCommentByIdQueryRequest> _objectBuilder;

    public GetPostCommentByIdQueryRequestBuilder(ObjectBuilder<GetPostCommentByIdQueryRequest> objectBuilder, PostComment postComment)
    {
        _objectBuilder = objectBuilder;

        WithId(postComment.Id);
        WithCommentId(postComment.CommentId);
    }

    public GetPostCommentByIdQueryRequestBuilder WithId(string id, IStringTransformer? transformer = null)
    {
        _objectBuilder.With(p => p.Id, id, transformer);

        return this;
    }

    public GetPostCommentByIdQueryRequestBuilder WithCommentId(string commentId, IStringTransformer? transformer = null)
    {
        _objectBuilder.With(p => p.CommentId, commentId, transformer);

        return this;
    }

    public GetPostCommentByIdQueryRequest Build()
    {
        return _objectBuilder.Build();
    }
}
