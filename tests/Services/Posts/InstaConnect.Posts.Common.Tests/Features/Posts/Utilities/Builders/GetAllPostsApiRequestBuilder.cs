using System.Drawing.Printing;

using InstaConnect.Common.Tests.Utilities;
using InstaConnect.Common.Tests.Utilities.Builders;
using InstaConnect.Posts.Application.Features.Posts.Queries.GetAll;
using InstaConnect.Posts.Application.Features.Posts.Queries.GetById;
using InstaConnect.Posts.Common.Tests.Features.Users.Utilities;
using InstaConnect.Posts.Domain.Features.Posts.Models.Requests;
using InstaConnect.Posts.Presentation.Features.Posts.Models.Requests;

namespace InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Builders;

public class GetAllPostsApiRequestBuilder
{
    private readonly ObjectBuilder<GetAllPostsApiRequest> _objectBuilder;

    public GetAllPostsApiRequestBuilder()
    {
        _objectBuilder = ObjectBuilderFactory.Build<GetAllPostsApiRequest>();

        WithUserId(UserDataFaker.GetId());
    }

    public GetAllPostsApiRequestBuilder(Post post, User user)
    {
        _objectBuilder = ObjectBuilderFactory.Build<GetAllPostsApiRequest>();

        WithUserId(user.Id);
        WithUserName(user.UserName);
        WithTitle(post.Title);
        WithPage(PostDataFaker.GetPage());
        WithPageSize(PostDataFaker.GetPageSize());
        WithSortOrder(PostDataFaker.GetSortOrder());
        WithSortProperty(PostDataFaker.GetSortProperty());
    }

    public GetAllPostsApiRequestBuilder WithUserId(string userId)
    {
        _objectBuilder.With(p => p.Filter.UserId, userId);

        return this;
    }

    public GetAllPostsApiRequestBuilder WithUserName(string userName)
    {
        _objectBuilder.With(p => p.Filter.UserName, userName);

        return this;
    }

    public GetAllPostsApiRequestBuilder WithTitle(string title)
    {
        _objectBuilder.With(p => p.Filter.Title, title);

        return this;
    }

    public GetAllPostsApiRequestBuilder WithPage(int page)
    {
        _objectBuilder.With(p => p.Pagination.Page, page);

        return this;
    }

    public GetAllPostsApiRequestBuilder WithPageSize(int pageSize)
    {
        _objectBuilder.With(p => p.Pagination.PageSize, pageSize);

        return this;
    }

    public GetAllPostsApiRequestBuilder WithSortOrder(SortOrder order)
    {
        _objectBuilder.With(p => p.Sorting.Order, order);

        return this;
    }

    public GetAllPostsApiRequestBuilder WithoutSortOrder()
    {
        _objectBuilder.With(p => p.Sorting.Order, PostDataFaker.GetEmptySortOrder());

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
