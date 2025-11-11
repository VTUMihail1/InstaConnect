using InstaConnect.Posts.Domain.Features.PostComments.Models.Requests;

namespace InstaConnect.Posts.Presentation.Tests.Features.PostComments.Builders;

public class GetAllPostCommentsApiRequestBuilder
{
    private string _id;
    private string _userId;
    private string _userName;
    private int _page;
    private int _pageSize;
    private SortOrder _sortOrder;
    private PostCommentSortProperty _sortProperty;

    public GetAllPostCommentsApiRequestBuilder(PostComment postComment, User user)
    {
        _id = postComment.Id;
        _userId = user.Id;
        _userName = user.Name;
        _page = PostCommentDataFaker.GetPage();
        _pageSize = PostCommentDataFaker.GetPageSize();
        _sortOrder = DataFaker.GetSortOrder();
        _sortProperty = PostCommentDataFaker.GetSortProperty();
    }

    public GetAllPostCommentsApiRequestBuilder WithId(string id, IStringTransformer? transformer = null)
    {
        _id = transformer.TryTransform(id);

        return this;
    }

    public GetAllPostCommentsApiRequestBuilder WithUserId(string userId, IStringTransformer? transformer = null)
    {
        _userId = transformer.TryTransform(userId);

        return this;
    }

    public GetAllPostCommentsApiRequestBuilder WithUserName(string userName, IStringTransformer? transformer = null)
    {
        _userName = transformer.TryTransform(userName);

        return this;
    }

    public GetAllPostCommentsApiRequestBuilder WithPage(int page, IIntTransformer? transformer = null)
    {
        _page = transformer.TryTransform(page);

        return this;
    }

    public GetAllPostCommentsApiRequestBuilder WithPageSize(int pageSize, IIntTransformer? transformer = null)
    {
        _pageSize = transformer.TryTransform(pageSize);

        return this;
    }

    public GetAllPostCommentsApiRequestBuilder WithSortOrder(SortOrder order, IEnumTransformer<SortOrder>? transformer = null)
    {
        _sortOrder = transformer.TryTransform(order);

        return this;
    }

    public GetAllPostCommentsApiRequestBuilder WithSortProperty(PostCommentSortProperty property, IEnumTransformer<PostCommentSortProperty>? transformer = null)
    {
        _sortProperty = transformer.TryTransform(property);

        return this;
    }

    public GetAllPostCommentsApiRequest Build()
    {
        return new(
            new(_id, _userId, _userName),
            new(_sortOrder, _sortProperty),
            new(_page, _pageSize)
        );
    }
}
