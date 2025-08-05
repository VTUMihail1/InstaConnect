using InstaConnect.Common.Tests.Utilities.Builders;
using InstaConnect.Common.Tests.Utilities.DataAttributes.Strings.Base;
using InstaConnect.PostCommentLikes.Application.Features.PostCommentLikes.Commands.Delete;
using InstaConnect.PostCommentLikes.Common.Tests.Features.PostCommentLikes.Utilities.Builders.DeleteCommandRequest;
using InstaConnect.PostCommentLikes.Domain.Features.PostCommentLikes.Models.Entities;
using InstaConnect.PostCommentLikes.Presentation.Features.PostCommentLikes.Models.Requests;
using InstaConnect.PostComments.Common.Tests.Features.PostComments.Utilities;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities;
using InstaConnect.Posts.Common.Tests.Features.Users.Utilities;

namespace InstaConnect.PostCommentLikes.Common.Tests.Features.PostCommentLikes.Utilities.Builders.GetByIdApiRequest;

public class GetPostCommentLikeByIdApiRequestBuilder
{
    private readonly ObjectBuilder<GetPostCommentLikeByIdApiRequest> _objectBuilder;

    public GetPostCommentLikeByIdApiRequestBuilder(ObjectBuilder<GetPostCommentLikeByIdApiRequest> objectBuilder)
    {
        _objectBuilder = objectBuilder;

        WithId(PostDataFaker.GetId());
        WithCommentId(PostCommentDataFaker.GetId());
        WithCommentLikeId(PostCommentLikeDataFaker.GetId());
    }

    public GetPostCommentLikeByIdApiRequestBuilder(ObjectBuilder<GetPostCommentLikeByIdApiRequest> objectBuilder, PostCommentLike postCommentLike)
    {
        _objectBuilder = objectBuilder;

        WithId(postCommentLike.Id);
        WithCommentId(postCommentLike.CommentId);
        WithCommentLikeId(postCommentLike.CommentLikeId);
    }

    public GetPostCommentLikeByIdApiRequestBuilder WithId(string id, IStringTransformer? transformer = null)
    {
        _objectBuilder.With(p => p.Id, id, transformer);

        return this;
    }

    public GetPostCommentLikeByIdApiRequestBuilder WithCommentId(string commentId, IStringTransformer? transformer = null)
    {
        _objectBuilder.With(p => p.CommentId, commentId, transformer);

        return this;
    }

    public GetPostCommentLikeByIdApiRequestBuilder WithCommentLikeId(string commentLikeId, IStringTransformer? transformer = null)
    {
        _objectBuilder.With(p => p.CommentLikeId, commentLikeId, transformer);

        return this;
    }

    public GetPostCommentLikeByIdApiRequest Create()
    {
        return _objectBuilder.Create();
    }
}
