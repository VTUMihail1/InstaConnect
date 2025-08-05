using InstaConnect.Common.Tests.Utilities.Builders;
using InstaConnect.Common.Tests.Utilities.DataAttributes.Strings.Base;
using InstaConnect.PostCommentLikes.Application.Features.PostCommentLikes.Commands.Delete;
using InstaConnect.PostCommentLikes.Application.Features.PostCommentLikes.Queries.GetById;
using InstaConnect.PostCommentLikes.Common.Tests.Features.PostCommentLikes.Utilities.Builders.DeleteCommandRequest;
using InstaConnect.PostCommentLikes.Domain.Features.PostCommentLikes.Models.Entities;
using InstaConnect.PostComments.Common.Tests.Features.PostComments.Utilities;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities;
using InstaConnect.Posts.Common.Tests.Features.Users.Utilities;

namespace InstaConnect.PostCommentLikes.Common.Tests.Features.PostCommentLikes.Utilities.Builders.GetByIdQueryRequest;

public class GetPostCommentLikeByIdQueryRequestBuilder
{
    private readonly ObjectBuilder<GetPostCommentLikeByIdQueryRequest> _objectBuilder;

    public GetPostCommentLikeByIdQueryRequestBuilder(ObjectBuilder<GetPostCommentLikeByIdQueryRequest> objectBuilder)
    {
        _objectBuilder = objectBuilder;

        WithId(PostDataFaker.GetId());
        WithCommentId(PostCommentDataFaker.GetId());
        WithCommentLikeId(PostCommentLikeDataFaker.GetId());
    }

    public GetPostCommentLikeByIdQueryRequestBuilder(ObjectBuilder<GetPostCommentLikeByIdQueryRequest> objectBuilder, PostCommentLike postCommentLike)
    {
        _objectBuilder = objectBuilder;

        WithId(postCommentLike.Id);
        WithCommentId(postCommentLike.CommentId);
        WithCommentLikeId(postCommentLike.CommentLikeId);
    }

    public GetPostCommentLikeByIdQueryRequestBuilder WithId(string id, IStringTransformer? transformer = null)
    {
        _objectBuilder.With(p => p.Id, id, transformer);

        return this;
    }

    public GetPostCommentLikeByIdQueryRequestBuilder WithCommentId(string commentId, IStringTransformer? transformer = null)
    {
        _objectBuilder.With(p => p.CommentId, commentId, transformer);

        return this;
    }

    public GetPostCommentLikeByIdQueryRequestBuilder WithCommentLikeId(string commentLikeId, IStringTransformer? transformer = null)
    {
        _objectBuilder.With(p => p.CommentLikeId, commentLikeId, transformer);

        return this;
    }

    public GetPostCommentLikeByIdQueryRequest Create()
    {
        return _objectBuilder.Create();
    }
}
