using InstaConnect.Common.Tests.DataAttributes.Base;

namespace InstaConnect.Posts.Application.Tests.Features.PostCommentLikes.Builders;

public class GetAllPostCommentLikesQueryRequestBuilder
{
    private string _id;
    private string _commentId;
    private string _userName;
    private int _page;
    private int _pageSize;
    private CommonSortOrder _sortOrder;
    private PostCommentLikeSortProperty _sortProperty;

    public GetAllPostCommentLikesQueryRequestBuilder(PostCommentLike postCommentLike, User user)
    {
        _id = postCommentLike.Id.CommentId.Id.Id;
        _commentId = postCommentLike.Id.CommentId.CommentId;
        _userName = user.Name.Value;
        _page = PostCommentLikeDataFaker.GetPage();
        _pageSize = PostCommentLikeDataFaker.GetPageSize();
        _sortOrder = DataFaker.GetSortOrder();
        _sortProperty = PostCommentLikeDataFaker.GetSortProperty();
    }

    public GetAllPostCommentLikesQueryRequestBuilder WithId(Post post, IStringTransformer? transformer = null)
    {
        _id = transformer.TryTransform(post.Id.Id);

        return this;
    }

    public GetAllPostCommentLikesQueryRequestBuilder WithId(IStringTransformer transformer)
    {
        _id = transformer.Transform(_id);

        return this;
    }

    public GetAllPostCommentLikesQueryRequestBuilder WithCommentId(PostComment postComment, IStringTransformer? transformer = null)
    {
        _commentId = transformer.TryTransform(postComment.Id.CommentId);

        return this;
    }

    public GetAllPostCommentLikesQueryRequestBuilder WithCommentId(IStringTransformer transformer)
    {
        _commentId = transformer.Transform(_commentId);

        return this;
    }

    public GetAllPostCommentLikesQueryRequestBuilder WithUserName(IStringTransformer transformer)
    {
        _userName = transformer.Transform(_userName);

        return this;
    }

    public GetAllPostCommentLikesQueryRequestBuilder WithPage(IIntTransformer transformer)
    {
        _page = transformer.Transform(_page);

        return this;
    }

    public GetAllPostCommentLikesQueryRequestBuilder WithPageSize(IIntTransformer transformer)
    {
        _pageSize = transformer.Transform(_pageSize);

        return this;
    }

    public GetAllPostCommentLikesQueryRequestBuilder WithSortOrder(IEnumTransformer<CommonSortOrder> transformer)
    {
        _sortOrder = transformer.Transform(_sortOrder);

        return this;
    }

    public GetAllPostCommentLikesQueryRequestBuilder WithSortProperty(IEnumTransformer<PostCommentLikeSortProperty> transformer)
    {
        _sortProperty = transformer.Transform(_sortProperty);

        return this;
    }

    public GetAllPostCommentLikesQueryRequest Build()
    {
        return new(_id, _commentId, _userName, _sortOrder, _sortProperty, _page, _pageSize);
    }
}
