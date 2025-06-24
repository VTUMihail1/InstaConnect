using System.Drawing.Printing;

using InstaConnect.Common.Tests.Utilities;
using InstaConnect.Common.Tests.Utilities.Builders;
using InstaConnect.Posts.Application.Features.Posts.Queries.GetAll;
using InstaConnect.Posts.Application.Features.Posts.Queries.GetById;
using InstaConnect.Posts.Common.Tests.Features.Users.Utilities;
using InstaConnect.Posts.Domain.Features.Posts.Models.Requests;

namespace InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Builders;

public class GetAllPostsQueryBuilder
{
    private readonly ObjectBuilder<GetAllPostsQuery> _objectBuilder;

    public GetAllPostsQueryBuilder()
    {
        _objectBuilder = ObjectBuilderFactory.Build<GetAllPostsQuery>();

        WithUserId(UserDataFaker.GetId());
    }

    public GetAllPostsQueryBuilder(Post post, User user)
    {
        _objectBuilder = ObjectBuilderFactory.Build<GetAllPostsQuery>();

        WithUserId(user.Id);
        WithUserName(user.UserName);
        WithTitle(post.Title);
        WithPage(PostDataFaker.GetPage());
        WithPageSize(PostDataFaker.GetPageSize());
        WithSortOrder(PostDataFaker.GetSortOrder());
        WithSortProperty(PostDataFaker.GetSortProperty());
    }

    public GetAllPostsQueryBuilder WithUserId(string userId)
    {
        _objectBuilder.With(p => p.Filter.UserId, userId);

        return this;
    }

    public GetAllPostsQueryBuilder WithDifferentCaseUserId(string userId)
    {
        _objectBuilder.With(p => p.Filter.UserId, DataFaker.GetDifferentCaseString(userId));

        return this;
    }

    public GetAllPostsQueryBuilder WithInvalidUserId()
    {
        _objectBuilder.With(p => p.Filter.UserId, UserDataFaker.GetInvalidId());

        return this;
    }

    public GetAllPostsQueryBuilder WithoutUserId()
    {
        _objectBuilder.Without(p => p.Filter.UserId);

        return this;
    }

    public GetAllPostsQueryBuilder WithUserName(string userName)
    {
        _objectBuilder.With(p => p.Filter.UserName, userName);

        return this;
    }

    public GetAllPostsQueryBuilder WithDifferentCaseUserName(string userName)
    {
        _objectBuilder.With(p => p.Filter.UserName, DataFaker.GetDifferentCaseString(userName));

        return this;
    }

    public GetAllPostsQueryBuilder WithoutUserName()
    {
        _objectBuilder.Without(p => p.Filter.UserName);

        return this;
    }

    public GetAllPostsQueryBuilder WithTitle(string title)
    {
        _objectBuilder.With(p => p.Filter.Title, title);

        return this;
    }

    public GetAllPostsQueryBuilder WithDifferentCaseTitle(string title)
    {
        _objectBuilder.With(p => p.Filter.Title, DataFaker.GetDifferentCaseString(title));

        return this;
    }

    public GetAllPostsQueryBuilder WithPrefixTitle(string title)
    {
        _objectBuilder.With(p => p.Filter.Title, DataFaker.GetPrefixString(title));

        return this;
    }

    public GetAllPostsQueryBuilder WithoutTitle()
    {
        _objectBuilder.Without(p => p.Filter.Title);

        return this;
    }

    public GetAllPostsQueryBuilder WithPage(int page)
    {
        _objectBuilder.With(p => p.Pagination.Page, page);

        return this;
    }

    public GetAllPostsQueryBuilder WithoutPage()
    {
        _objectBuilder.Without(p => p.Pagination.Page);

        return this;
    }

    public GetAllPostsQueryBuilder WithPageSize(int pageSize)
    {
        _objectBuilder.With(p => p.Pagination.PageSize, pageSize);

        return this;
    }

    public GetAllPostsQueryBuilder WithoutPageSize()
    {
        _objectBuilder.Without(p => p.Pagination.PageSize);

        return this;
    }

    public GetAllPostsQueryBuilder WithSortOrder(SortOrder order)
    {
        _objectBuilder.With(p => p.Sorting.Order, order);

        return this;
    }

    public GetAllPostsQueryBuilder WithEmptySortOrder()
    {
        _objectBuilder.With(p => p.Sorting.Order, PostDataFaker.GetEmptySortOrder());

        return this;
    }

    public GetAllPostsQueryBuilder WithSortProperty(PostSortProperty property)
    {
        _objectBuilder.With(p => p.Sorting.Property, property);

        return this;
    }

    public GetAllPostsQueryBuilder WithEmptySortProperty()
    {
        _objectBuilder.With(p => p.Sorting.Property, PostDataFaker.GetEmptySortProperty());

        return this;
    }

    public GetAllPostsQuery Create()
    {
        return _objectBuilder.Create();
    }
}
