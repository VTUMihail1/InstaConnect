namespace InstaConnect.Posts.Application.Tests.Features.Posts.Builders;

public class GetAllPostsQueryRequestBuilder
{
    private readonly ObjectBuilder<GetAllPostsQueryRequest> _objectBuilder;

    public GetAllPostsQueryRequestBuilder(ObjectBuilder<GetAllPostsQueryRequest> objectBuilder, Post post, User user)
    {
        _objectBuilder = objectBuilder;

        WithUserId(user.Id);
        WithUserName(user.Name);
        WithTitle(post.Title);
        WithPage(PostDataFaker.GetPage());
        WithPageSize(PostDataFaker.GetPageSize());
        WithSortOrder(DataFaker.GetSortOrder());
        WithSortProperty(PostDataFaker.GetSortProperty());
    }

    public GetAllPostsQueryRequestBuilder WithUserId(string userId, IStringTransformer? transformer = null)
    {
        _objectBuilder.WithString(p => p.Filter.UserId, userId, transformer);

        return this;
    }

    public GetAllPostsQueryRequestBuilder WithUserName(string userName, IStringTransformer? transformer = null)
    {
        _objectBuilder.WithString(p => p.Filter.UserName, userName, transformer);

        return this;
    }

    public GetAllPostsQueryRequestBuilder WithTitle(string title, IStringTransformer? transformer = null)
    {
        _objectBuilder.WithString(p => p.Filter.Title, title, transformer);

        return this;
    }

    public GetAllPostsQueryRequestBuilder WithPage(int page, IIntTransformer? transformer = null)
    {
        _objectBuilder.WithInt(p => p.Pagination.Page, page, transformer);

        return this;
    }

    public GetAllPostsQueryRequestBuilder WithPageSize(int pageSize, IIntTransformer? transformer = null)
    {
        _objectBuilder.WithInt(p => p.Pagination.PageSize, pageSize, transformer);

        return this;
    }

    public GetAllPostsQueryRequestBuilder WithSortOrder(SortOrder order, IEnumTransformer<SortOrder>? transformer = null)
    {
        _objectBuilder.WithEnum(p => p.Sorting.Order, order, transformer);

        return this;
    }

    public GetAllPostsQueryRequestBuilder WithSortProperty(PostSortProperty property, IEnumTransformer<PostSortProperty>? transformer = null)
    {
        _objectBuilder.WithEnum(p => p.Sorting.Property, property, transformer);

        return this;
    }

    public GetAllPostsQueryRequest Build()
    {
        return _objectBuilder.Build();
    }
}
