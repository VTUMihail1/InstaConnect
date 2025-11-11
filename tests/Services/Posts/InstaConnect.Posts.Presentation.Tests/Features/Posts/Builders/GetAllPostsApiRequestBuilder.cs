using InstaConnect.Posts.Domain.Features.Posts.Models.Requests;

namespace InstaConnect.Posts.Presentation.Tests.Features.Posts.Builders;

public class GetAllPostsApiRequestBuilder
{
    private string _userId;
    private string _userName;
    private string _title;
    private int _page;
    private int _pageSize;
    private SortOrder _sortOrder;
    private PostSortProperty _sortProperty;

    public GetAllPostsApiRequestBuilder(Post post, User user)
    {
        _userId = user.Id;
        _userName = user.Name;
        _title = post.Title;
        _page = PostDataFaker.GetPage();
        _pageSize = PostDataFaker.GetPageSize();
        _sortOrder = DataFaker.GetSortOrder();
        _sortProperty = PostDataFaker.GetSortProperty();
    }

    public GetAllPostsApiRequestBuilder WithUserId(string userId, IStringTransformer? transformer = null)
    {
        _userId = transformer.TryTransform(userId);

        return this;
    }

    public GetAllPostsApiRequestBuilder WithUserName(string userName, IStringTransformer? transformer = null)
    {
        _userName = transformer.TryTransform(userName);

        return this;
    }

    public GetAllPostsApiRequestBuilder WithTitle(string title, IStringTransformer? transformer = null)
    {
        _title = transformer.TryTransform(title);

        return this;
    }

    public GetAllPostsApiRequestBuilder WithPage(int page, IIntTransformer? transformer = null)
    {
        _page = transformer.TryTransform(page);

        return this;
    }

    public GetAllPostsApiRequestBuilder WithPageSize(int pageSize, IIntTransformer? transformer = null)
    {
        _pageSize = transformer.TryTransform(pageSize);

        return this;
    }

    public GetAllPostsApiRequestBuilder WithSortOrder(SortOrder order, IEnumTransformer<SortOrder>? transformer = null)
    {
        _sortOrder = transformer.TryTransform(order);

        return this;
    }

    public GetAllPostsApiRequestBuilder WithSortProperty(PostSortProperty property, IEnumTransformer<PostSortProperty>? transformer = null)
    {
        _sortProperty = transformer.TryTransform(property);

        return this;
    }

    public GetAllPostsApiRequest Build()
    {
        return new(
            new(_userId, _userName, _title),
            new(_sortOrder, _sortProperty),
            new(_page, _pageSize)
        );
    }
}
