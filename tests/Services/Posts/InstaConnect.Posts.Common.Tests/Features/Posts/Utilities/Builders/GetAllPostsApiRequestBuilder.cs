using System.Drawing.Printing;

using InstaConnect.Common.Tests.Utilities;
using InstaConnect.Common.Tests.Utilities.Types.Enums.Base;
using InstaConnect.Common.Tests.Utilities.Types.Ints.Base;
using InstaConnect.Common.Tests.Utilities.Types.Strings.Base;
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

    public GetAllPostsApiRequestBuilder()
    {
        WithUserId(UserDataFaker.GetId());
        WithUserName(UserDataFaker.GetName());
        WithTitle(PostDataFaker.GetTitle());
        WithPage(PostDataFaker.GetPage());
        WithPageSize(PostDataFaker.GetPageSize());
        WithSortOrder(DataFaker.GetSortOrder());
        WithSortProperty(PostDataFaker.GetSortProperty());
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

    public GetAllPostsApiRequestBuilder WithUserId(string userId, IStringTransformer? transformer = null)
    {
        _objectBuilder.With(p => p.Filter.UserId, userId, transformer);

        return this;
    }

    public GetAllPostsApiRequestBuilder WithUserName(string userName, IStringTransformer? transformer = null)
    {
        _objectBuilder.With(p => p.Filter.UserName, userName, transformer);

        return this;
    }

    public GetAllPostsApiRequestBuilder WithTitle(string title, IStringTransformer? transformer = null)
    {
        _objectBuilder.With(p => p.Filter.Title, title, transformer);

        return this;
    }

    public GetAllPostsApiRequestBuilder WithPage(int page, IIntTransformer? transformer = null)
    {
        _objectBuilder.With(p => p.Pagination.Page, page, transformer);

        return this;
    }

    public GetAllPostsApiRequestBuilder WithPageSize(int pageSize, IIntTransformer? transformer = null)
    {
        _objectBuilder.With(p => p.Pagination.PageSize, pageSize, transformer);

        return this;
    }

    public GetAllPostsApiRequestBuilder WithSortOrder(SortOrder order, IEnumTransformer<SortOrder>? transformer = null)
    {
        _objectBuilder.With(p => p.Sorting.Order, order, transformer);

        return this;
    }

    public GetAllPostsApiRequestBuilder WithSortProperty(PostSortProperty property, IEnumTransformer<PostSortProperty>? transformer = null)
    {
        _objectBuilder.With(p => p.Sorting.Property, property, transformer);

        return this;
    }

    public GetAllPostsApiRequest Create()
    {
        return _objectBuilder.Create();
    }
}
