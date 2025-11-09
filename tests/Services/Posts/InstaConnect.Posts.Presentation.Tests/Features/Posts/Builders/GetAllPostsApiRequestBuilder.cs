using InstaConnect.Posts.Domain.Features.Posts.Models.Requests;

namespace InstaConnect.Posts.Presentation.Tests.Features.Posts.Builders;

public class GetAllPostsApiRequestBuilder
{
    private readonly ObjectBuilder<GetAllPostsApiRequest> _objectBuilder;

    public GetAllPostsApiRequestBuilder(ObjectBuilder<GetAllPostsApiRequest> objectBuilder, Post post, User user)
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

    public GetAllPostsApiRequestBuilder WithUserId(string userId, IStringTransformer? transformer = null)
    {
        _objectBuilder.WithString(p => p.Filter.UserId, userId, transformer);

        return this;
    }

    public GetAllPostsApiRequestBuilder WithUserName(string userName, IStringTransformer? transformer = null)
    {
        _objectBuilder.WithString(p => p.Filter.UserName, userName, transformer);

        return this;
    }

    public GetAllPostsApiRequestBuilder WithTitle(string title, IStringTransformer? transformer = null)
    {
        _objectBuilder.WithString(p => p.Filter.Title, title, transformer);

        return this;
    }

    public GetAllPostsApiRequestBuilder WithPage(int page, IIntTransformer? transformer = null)
    {
        _objectBuilder.WithInt(p => p.Pagination.Page, page, transformer);

        return this;
    }

    public GetAllPostsApiRequestBuilder WithPageSize(int pageSize, IIntTransformer? transformer = null)
    {
        _objectBuilder.WithInt(p => p.Pagination.PageSize, pageSize, transformer);

        return this;
    }

    public GetAllPostsApiRequestBuilder WithSortOrder(SortOrder order, IEnumTransformer<SortOrder>? transformer = null)
    {
        _objectBuilder.WithEnum(p => p.Sorting.Order, order, transformer);

        return this;
    }

    public GetAllPostsApiRequestBuilder WithSortProperty(PostSortProperty property, IEnumTransformer<PostSortProperty>? transformer = null)
    {
        _objectBuilder.WithEnum(p => p.Sorting.Property, property, transformer);

        return this;
    }

    public GetAllPostsApiRequest Build()
    {
        return _objectBuilder.Build();
    }
}
