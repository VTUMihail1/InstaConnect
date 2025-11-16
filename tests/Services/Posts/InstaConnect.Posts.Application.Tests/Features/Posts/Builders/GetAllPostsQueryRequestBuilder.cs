using InstaConnect.Common.Tests.DataAttributes.Base;

namespace InstaConnect.Posts.Application.Tests.Features.Posts.Builders;

public class GetAllPostsQueryRequestBuilder
{
    private string _userId;
    private string _userName;
    private string _title;
    private int _page;
    private int _pageSize;
    private CommonSortOrder _sortOrder;
    private PostSortProperty _sortProperty;

    public GetAllPostsQueryRequestBuilder(Post post, User user)
    {
        _userId = user.Id;
        _userName = user.Name;
        _title = post.Title;
        _page = PostDataFaker.GetPage();
        _pageSize = PostDataFaker.GetPageSize();
        _sortOrder = DataFaker.GetSortOrder();
        _sortProperty = PostDataFaker.GetSortProperty();
    }

    public GetAllPostsQueryRequestBuilder WithUserId(string userId, IStringTransformer? transformer = null)
    {
        _userId = transformer.TryTransform(userId);

        return this;
    }

    public GetAllPostsQueryRequestBuilder WithUserName(string userName, IStringTransformer? transformer = null)
    {
        _userName = transformer.TryTransform(userName);

        return this;
    }

    public GetAllPostsQueryRequestBuilder WithTitle(string title, IStringTransformer? transformer = null)
    {
        _title = transformer.TryTransform(title);

        return this;
    }

    public GetAllPostsQueryRequestBuilder WithPage(int page, IIntTransformer? transformer = null)
    {
        _page = transformer.TryTransform(page);

        return this;
    }

    public GetAllPostsQueryRequestBuilder WithPageSize(int pageSize, IIntTransformer? transformer = null)
    {
        _pageSize = transformer.TryTransform(pageSize);

        return this;
    }

    public GetAllPostsQueryRequestBuilder WithSortOrder(CommonSortOrder order, IEnumTransformer<CommonSortOrder>? transformer = null)
    {
        _sortOrder = transformer.TryTransform(order);

        return this;
    }

    public GetAllPostsQueryRequestBuilder WithSortProperty(PostSortProperty property, IEnumTransformer<PostSortProperty>? transformer = null)
    {
        _sortProperty = transformer.TryTransform(property);

        return this;
    }

    public GetAllPostsQueryRequest Build()
    {
        return new(
            new(_userId, _userName, _title),
            new(_sortOrder, _sortProperty),
            new(_page, _pageSize)
        );
    }
}
