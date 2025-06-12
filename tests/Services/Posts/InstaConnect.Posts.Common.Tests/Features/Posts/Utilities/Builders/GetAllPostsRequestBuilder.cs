using System.Drawing.Printing;

using InstaConnect.Common.Tests.Utilities;
using InstaConnect.Common.Tests.Utilities.Builders;
using InstaConnect.Posts.Application.Features.Posts.Queries.GetAll;
using InstaConnect.Posts.Application.Features.Posts.Queries.GetById;
using InstaConnect.Posts.Common.Tests.Features.Users.Utilities;
using InstaConnect.Posts.Domain.Features.Posts.Models;
using InstaConnect.Posts.Presentation.Features.Posts.Models.Requests;

namespace InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Builders;

public class GetAllPostsRequestBuilder
{
    private readonly ObjectBuilder<GetAllPostsRequest> _objectBuilder;

    public GetAllPostsRequestBuilder()
    {
        _objectBuilder = ObjectBuilderFactory.Build<GetAllPostsRequest>();

        WithUserId(UserDataFaker.GetId());
    }

    public GetAllPostsRequestBuilder(Post post, User user)
    {
        _objectBuilder = ObjectBuilderFactory.Build<GetAllPostsRequest>();

        WithUserId(user.Id);
        WithUserName(user.UserName);
        WithTitle(post.Title);
        WithPage(PostDataFaker.GetPage());
        WithPageSize(PostDataFaker.GetPageSize());
        WithSortOrder(PostDataFaker.GetSortOrder());
        WithSortProperty(PostDataFaker.GetSortProperty());
    }

    public GetAllPostsRequestBuilder WithUserId(string userId)
    {
        _objectBuilder.With(p => p.Filter.UserId, userId);

        return this;
    }

    public GetAllPostsRequestBuilder WithDifferentCaseUserId(string userId)
    {
        _objectBuilder.With(p => p.Filter.UserId, DataFaker.GetDifferentCaseString(userId));

        return this;
    }

    public GetAllPostsRequestBuilder WithInvalidUserId()
    {
        _objectBuilder.With(p => p.Filter.UserId, UserDataFaker.GetInvalidId());

        return this;
    }

    public GetAllPostsRequestBuilder WithoutUserId()
    {
        _objectBuilder.Without(p => p.Filter.UserId);

        return this;
    }

    public GetAllPostsRequestBuilder WithUserName(string userName)
    {
        _objectBuilder.With(p => p.Filter.UserName, userName);

        return this;
    }

    public GetAllPostsRequestBuilder WithDifferentCaseUserName(string userName)
    {
        _objectBuilder.With(p => p.Filter.UserName, DataFaker.GetDifferentCaseString(userName));

        return this;
    }

    public GetAllPostsRequestBuilder WithoutUserName()
    {
        _objectBuilder.Without(p => p.Filter.UserName);

        return this;
    }

    public GetAllPostsRequestBuilder WithTitle(string title)
    {
        _objectBuilder.With(p => p.Filter.Title, title);

        return this;
    }

    public GetAllPostsRequestBuilder WithDifferentCaseTitle(string title)
    {
        _objectBuilder.With(p => p.Filter.Title, DataFaker.GetDifferentCaseString(title));

        return this;
    }

    public GetAllPostsRequestBuilder WithPrefixTitle(string title)
    {
        _objectBuilder.With(p => p.Filter.Title, DataFaker.GetPrefixString(title));

        return this;
    }

    public GetAllPostsRequestBuilder WithoutTitle()
    {
        _objectBuilder.Without(p => p.Filter.Title);

        return this;
    }

    public GetAllPostsRequestBuilder WithPage(int page)
    {
        _objectBuilder.With(p => p.Pagination.Page, page);

        return this;
    }

    public GetAllPostsRequestBuilder WithoutPage()
    {
        _objectBuilder.Without(p => p.Pagination.Page);

        return this;
    }

    public GetAllPostsRequestBuilder WithPageSize(int pageSize)
    {
        _objectBuilder.With(p => p.Pagination.PageSize, pageSize);

        return this;
    }

    public GetAllPostsRequestBuilder WithoutPageSize()
    {
        _objectBuilder.Without(p => p.Pagination.PageSize);

        return this;
    }

    public GetAllPostsRequestBuilder WithSortOrder(SortOrder order)
    {
        _objectBuilder.With(p => p.Sorting.Order, order);

        return this;
    }

    public GetAllPostsRequestBuilder WithoutSortOrder()
    {
        _objectBuilder.With(p => p.Sorting.Order, PostDataFaker.GetEmptySortOrder());

        return this;
    }

    public GetAllPostsRequestBuilder WithSortProperty(PostSortProperty property)
    {
        _objectBuilder.With(p => p.Sorting.Property, property);

        return this;
    }

    public GetAllPostsRequestBuilder WithoutSortProperty()
    {
        _objectBuilder.With(p => p.Sorting.Property, PostDataFaker.GetEmptySortProperty());

        return this;
    }

    public GetAllPostsRequest Create()
    {
        return _objectBuilder.Create();
    }
}
