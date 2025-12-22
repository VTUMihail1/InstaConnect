namespace InstaConnect.Posts.Application.Tests.Features.Posts.Builders;

public class GetAllPostsQueryRequestBuilder
{
    private string _userName;
    private string _title;
    private int _page;
    private int _pageSize;
    private CommonSortOrder _sortOrder;
    private PostSortProperty _sortProperty;

    public GetAllPostsQueryRequestBuilder(Post post)
    {
        _userName = DataFaker.GetPrefixString(post.User!.Name.Value);
        _title = DataFaker.GetPrefixString(post.Title);
        _page = PostDataFaker.GetPage();
        _pageSize = PostDataFaker.GetPageSize();
        _sortOrder = DataFaker.GetSortOrder();
        _sortProperty = PostDataFaker.GetSortProperty();
    }

    public GetAllPostsQueryRequestBuilder WithUserName(IStringTransformer transformer)
    {
        _userName = transformer.Transform(_userName);

        return this;
    }

    public GetAllPostsQueryRequestBuilder WithTitle(IStringTransformer transformer)
    {
        _title = transformer.Transform(_title);

        return this;
    }

    public GetAllPostsQueryRequestBuilder WithPage(IIntTransformer transformer)
    {
        _page = transformer.Transform(_page);

        return this;
    }

    public GetAllPostsQueryRequestBuilder WithPageSize(IIntTransformer transformer)
    {
        _pageSize = transformer.Transform(_pageSize);

        return this;
    }

    public GetAllPostsQueryRequestBuilder WithSortOrder(IEnumTransformer<CommonSortOrder> transformer)
    {
        _sortOrder = transformer.Transform(_sortOrder);

        return this;
    }

    public GetAllPostsQueryRequestBuilder WithSortProperty(IEnumTransformer<PostSortProperty> transformer)
    {
        _sortProperty = transformer.Transform(_sortProperty);

        return this;
    }

    public GetAllPostsQueryRequest Build()
    {
        return new(_userName, _title, _sortOrder, _sortProperty, _page, _pageSize);
    }
}
