using System.Drawing.Printing;

using InstaConnect.Common.Tests.Utilities;
using InstaConnect.Common.Tests.Utilities.Variants.Int;
using InstaConnect.Common.Tests.Utilities.Variants.String;
using InstaConnect.Posts.Application.Features.Posts.Queries.GetAll;
using InstaConnect.Posts.Application.Features.Posts.Queries.GetById;
using InstaConnect.Posts.Common.Tests.Features.Users.Utilities;
using InstaConnect.Posts.Common.Tests.Features.Users.Utilities.Builders;
using InstaConnect.Posts.Domain.Features.Posts.Models.Requests;
using InstaConnect.Posts.Presentation.Features.Posts.Models.Requests;

namespace InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Builders;

public class GetAllPostsApiRequestBuilder
{
    private readonly ObjectBuilder<GetAllPostsApiRequest> _objectBuilder = new();

    public GetAllPostsApiRequestBuilder() : this(new PostBuilder().Create(), new UserBuilder().Create())
    {
    }

    public GetAllPostsApiRequestBuilder(Post post, User user)
    {
        WithUserId(user.Id);
        WithUserName(user.UserName);
        WithTitle(post.Title);
        WithPage(PostDataFaker.GetPage());
        WithPageSize(PostDataFaker.GetPageSize());
        WithSortOrder(DataFaker.GetSortOrder());
        WithSortProperty(PostDataFaker.GetSortProperty());
    }

    public GetAllPostsApiRequestBuilder WithUserId(string userId, StringVariantType type = StringVariantType.Default)
    {
        _objectBuilder.With(p => p.Filter.UserId, userId, type);

        return this;
    }

    public GetAllPostsApiRequestBuilder WithUserName(string userName, StringVariantType type = StringVariantType.Default)
    {
        _objectBuilder.With(p => p.Filter.UserName, userName, type);

        return this;
    }

    public GetAllPostsApiRequestBuilder WithTitle(string title, StringVariantType type = StringVariantType.Default)
    {
        _objectBuilder.With(p => p.Filter.Title, title, type);

        return this;
    }

    public GetAllPostsApiRequestBuilder WithPage(int page, IntVariantType type = IntVariantType.Default)
    {
        _objectBuilder.With(p => p.Pagination.Page, page, type);

        return this;
    }

    public GetAllPostsApiRequestBuilder WithPageSize(int pageSize, IntVariantType type = IntVariantType.Default)
    {
        _objectBuilder.With(p => p.Pagination.PageSize, pageSize, type);

        return this;
    }

    public GetAllPostsApiRequestBuilder WithSortOrder(SortOrder order)
    {
        _objectBuilder.With(p => p.Sorting.Order, order);

        return this;
    }

    public GetAllPostsApiRequestBuilder WithoutSortOrder()
    {
        _objectBuilder.With(p => p.Sorting.Order, DataFaker.GetEmptySortOrder());

        return this;
    }

    public GetAllPostsApiRequestBuilder WithSortProperty(PostSortProperty property)
    {
        _objectBuilder.With(p => p.Sorting.Property, property);

        return this;
    }

    public GetAllPostsApiRequestBuilder WithoutSortProperty()
    {
        _objectBuilder.With(p => p.Sorting.Property, PostDataFaker.GetEmptySortProperty());

        return this;
    }

    public GetAllPostsApiRequest Create()
    {
        return _objectBuilder.Create();
    }
}
