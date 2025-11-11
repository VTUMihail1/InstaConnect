using InstaConnect.Common.Tests.DataAttributes.Base;

namespace InstaConnect.Posts.Application.Tests.Features.PostCommentLikes.Builders;

public class GetAllPostCommentLikesQueryRequestBuilder
{
    private string _id;
    private string _commentId;
    private string _userName;
    private int _page;
    private int _pageSize;
    private SortOrder _sortOrder;
    private PostCommentLikeSortProperty _sortProperty;

    public GetAllPostCommentLikesQueryRequestBuilder(PostCommentLike postCommentLike, User user)
    {
        _id = postCommentLike.Id;
        _commentId = postCommentLike.CommentId;
        _userName = user.Name;
        _page = PostCommentLikeDataFaker.GetPage();
        _pageSize = PostCommentLikeDataFaker.GetPageSize();
        _sortOrder = DataFaker.GetSortOrder();
        _sortProperty = PostCommentLikeDataFaker.GetSortProperty();
    }

    public GetAllPostCommentLikesQueryRequestBuilder WithId(string id, IStringTransformer? transformer = null)
    {
        _id = transformer.TryTransform(id);

        return this;
    }

    public GetAllPostCommentLikesQueryRequestBuilder WithCommentId(string commentId, IStringTransformer? transformer = null)
    {
        _commentId = transformer.TryTransform(commentId);

        return this;
    }

    public GetAllPostCommentLikesQueryRequestBuilder WithUserName(string userName, IStringTransformer? transformer = null)
    {
        _userName = transformer.TryTransform(userName);

        return this;
    }

    public GetAllPostCommentLikesQueryRequestBuilder WithPage(int page, IIntTransformer? transformer = null)
    {
        _page = transformer.TryTransform(page);

        return this;
    }

    public GetAllPostCommentLikesQueryRequestBuilder WithPageSize(int pageSize, IIntTransformer? transformer = null)
    {
        _pageSize = transformer.TryTransform(pageSize);

        return this;
    }

    public GetAllPostCommentLikesQueryRequestBuilder WithSortOrder(SortOrder order, IEnumTransformer<SortOrder>? transformer = null)
    {
        _sortOrder = transformer.TryTransform(order);

        return this;
    }

    public GetAllPostCommentLikesQueryRequestBuilder WithSortProperty(PostCommentLikeSortProperty property, IEnumTransformer<PostCommentLikeSortProperty>? transformer = null)
    {
        _sortProperty = transformer.TryTransform(property);

        return this;
    }

    public GetAllPostCommentLikesQueryRequest Build()
    {
        return new(
            new(_id, _commentId, _userName),
            new(_sortOrder, _sortProperty),
            new(_page, _pageSize)
        );
    }
}
