using System.Drawing.Printing;

using InstaConnect.Common.Tests.Utilities;
using InstaConnect.Common.Tests.Utilities.Variants.Int;
using InstaConnect.Common.Tests.Utilities.Variants.String;
using InstaConnect.Posts.Application.Features.Posts.Queries.GetAll;
using InstaConnect.Posts.Application.Features.Posts.Queries.GetById;
using InstaConnect.Posts.Common.Tests.Features.Users.Utilities;
using InstaConnect.Posts.Common.Tests.Features.Users.Utilities.Builders;
using InstaConnect.Posts.Domain.Features.Posts.Models.Requests;

namespace InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Builders;

public class GetAllPostsQueryBuilder
{
    private readonly ObjectBuilder<GetAllPostsQuery> _objectBuilder = new();

    public GetAllPostsQueryBuilder() : this(new PostBuilder().Create(), new UserBuilder().Create())
    {
    }

    public GetAllPostsQueryBuilder(Post post, User user)
    {
        WithUserId(user.Id);
        WithUserName(user.UserName);
        WithTitle(post.Title);
        WithPage(PostDataFaker.GetPage());
        WithPageSize(PostDataFaker.GetPageSize());
        WithSortOrder(DataFaker.GetSortOrder());
        WithSortProperty(PostDataFaker.GetSortProperty());
    }

    public GetAllPostsQueryBuilder WithUserId(string userId, StringVariantType type = StringVariantType.Default)
    {
        _objectBuilder.With(p => p.Filter.UserId, userId, type);

        return this;
    }

    public GetAllPostsQueryBuilder WithUserName(string userName, StringVariantType type = StringVariantType.Default)
    {
        _objectBuilder.With(p => p.Filter.UserName, userName, type);

        return this;
    }

    public GetAllPostsQueryBuilder WithTitle(string title, StringVariantType type = StringVariantType.Default)
    {
        _objectBuilder.With(p => p.Filter.Title, title, type);

        return this;
    }

    public GetAllPostsQueryBuilder WithPage(int page, IntVariantType type = IntVariantType.Default)
    {
        _objectBuilder.With(p => p.Pagination.Page, page, type);

        return this;
    }

    public GetAllPostsQueryBuilder WithPageSize(int pageSize, IntVariantType type = IntVariantType.Default)
    {
        _objectBuilder.With(p => p.Pagination.PageSize, pageSize, type);

        return this;
    }

    public GetAllPostsQueryBuilder WithSortOrder(SortOrder order)
    {
        _objectBuilder.With(p => p.Sorting.Order, order);

        return this;
    }

    public GetAllPostsQueryBuilder WithSortProperty(PostSortProperty property)
    {
        _objectBuilder.With(p => p.Sorting.Property, property);

        return this;
    }

    public GetAllPostsQuery Create()
    {
        return _objectBuilder.Create();
    }
}
