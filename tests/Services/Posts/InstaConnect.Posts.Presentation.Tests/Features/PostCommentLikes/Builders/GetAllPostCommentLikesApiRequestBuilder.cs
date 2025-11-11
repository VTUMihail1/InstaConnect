using InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.Requests;

namespace InstaConnect.Posts.Presentation.Tests.Features.PostCommentLikes.Builders;

public class GetAllPostCommentLikesApiRequestBuilder
{
    private string _id;
    private string _commentId;
    private string _userName;
    private int _page;
    private int _pageSize;
    private SortOrder _sortOrder;
    private PostCommentLikeSortProperty _sortProperty;

    public GetAllPostCommentLikesApiRequestBuilder(PostCommentLike postCommentLike, User user)
    {
        _id = postCommentLike.Id;
        _commentId = postCommentLike.CommentId;
        _userName = user.Name;
        _page = PostCommentLikeDataFaker.GetPage();
        _pageSize = PostCommentLikeDataFaker.GetPageSize();
        _sortOrder = DataFaker.GetSortOrder();
        _sortProperty = PostCommentLikeDataFaker.GetSortProperty();
    }

    public GetAllPostCommentLikesApiRequestBuilder WithId(string id, IStringTransformer? transformer = null)
    {
        _id = transformer.TryTransform(id);

        return this;
    }

    public GetAllPostCommentLikesApiRequestBuilder WithCommentId(string commentId, IStringTransformer? transformer = null)
    {
        _commentId = transformer.TryTransform(commentId);

        return this;
    }

    public GetAllPostCommentLikesApiRequestBuilder WithUserName(string userName, IStringTransformer? transformer = null)
    {
        _userName = transformer.TryTransform(userName);

        return this;
    }

    public GetAllPostCommentLikesApiRequestBuilder WithPage(int page, IIntTransformer? transformer = null)
    {
        _page = transformer?.Transform(page) ?? page;

        return this;
    }

    public GetAllPostCommentLikesApiRequestBuilder WithPageSize(int pageSize, IIntTransformer? transformer = null)
    {
        _pageSize = transformer?.Transform(pageSize) ?? pageSize;

        return this;
    }

    public GetAllPostCommentLikesApiRequestBuilder WithSortOrder(SortOrder order, IEnumTransformer<SortOrder>? transformer = null)
    {
        _sortOrder = transformer?.Transform(order) ?? order;

        return this;
    }

    public GetAllPostCommentLikesApiRequestBuilder WithSortProperty(PostCommentLikeSortProperty property, IEnumTransformer<PostCommentLikeSortProperty>? transformer = null)
    {
        _sortProperty = transformer?.Transform(property) ?? property;

        return this;
    }

    public GetAllPostCommentLikesApiRequest Build()
    {
        return new(
            new(_id, _commentId, _userName),
            new(_sortOrder, _sortProperty),
            new(_page, _pageSize)
        );
    }
}
