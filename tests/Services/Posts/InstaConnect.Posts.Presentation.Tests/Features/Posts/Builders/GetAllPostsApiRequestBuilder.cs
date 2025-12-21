using InstaConnect.Posts.Domain.Features.Posts.Models.Requests;

namespace InstaConnect.Posts.Presentation.Tests.Features.Posts.Builders;

public class GetAllPostsApiRequestBuilder
{
    private string _userName;
    private string _title;
    private int _page;
    private int _pageSize;
    private CommonSortOrder _sortOrder;
    private PostSortProperty _sortProperty;

    public GetAllPostsApiRequestBuilder(Post post)
    {
        _userName = DataFaker.GetPrefixString(post.User!.Name.Value);
        _title = DataFaker.GetPrefixString(post.Title);
        _page = PostDataFaker.GetPage();
        _pageSize = PostDataFaker.GetPageSize();
        _sortOrder = DataFaker.GetSortOrder();
        _sortProperty = PostDataFaker.GetSortProperty();
    }

    public GetAllPostsApiRequestBuilder WithUserName(IStringTransformer transformer)
    {
        _userName = transformer.Transform(_userName);

        return this;
    }

    public GetAllPostsApiRequestBuilder WithTitle(IStringTransformer transformer)
    {
        _title = transformer.Transform(_title);

        return this;
    }

    public GetAllPostsApiRequestBuilder WithPage(IIntTransformer transformer)
    {
        _page = transformer.Transform(_page);

        return this;
    }

    public GetAllPostsApiRequestBuilder WithPageSize(IIntTransformer transformer)
    {
        _pageSize = transformer.Transform(_pageSize);

        return this;
    }

    public GetAllPostsApiRequestBuilder WithSortOrder(IEnumTransformer<CommonSortOrder> transformer)
    {
        _sortOrder = transformer.Transform(_sortOrder);

        return this;
    }

    public GetAllPostsApiRequestBuilder WithSortProperty(IEnumTransformer<PostSortProperty> transformer)
    {
        _sortProperty = transformer.Transform(_sortProperty);

        return this;
    }

    public GetAllPostsApiRequest Build()
    {
        return new(_userName, _title, _sortOrder, _sortProperty, _page, _pageSize);
    }
}
