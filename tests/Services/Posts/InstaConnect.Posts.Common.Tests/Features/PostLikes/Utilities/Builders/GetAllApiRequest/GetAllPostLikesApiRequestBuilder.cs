using System.Drawing.Printing;

using InstaConnect.Common.Tests.Utilities;
using InstaConnect.Common.Tests.Utilities.Builders;
using InstaConnect.Common.Tests.Utilities.DataAttributes.Enums.Base;
using InstaConnect.Common.Tests.Utilities.DataAttributes.Ints.Base;
using InstaConnect.Common.Tests.Utilities.DataAttributes.Strings.Base;
using InstaConnect.PostLikes.Application.Features.PostLikes.Queries.GetAll;
using InstaConnect.PostLikes.Application.Features.PostLikes.Queries.GetById;
using InstaConnect.PostLikes.Common.Tests.Features.Users.Utilities;
using InstaConnect.PostLikes.Common.Tests.Features.Users.Utilities.Builders;
using InstaConnect.PostLikes.Domain.Features.PostLikes.Models.Entities;
using InstaConnect.PostLikes.Domain.Features.PostLikes.Models.Requests;
using InstaConnect.PostLikes.Presentation.Features.PostLikes.Models.Requests;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities;
using InstaConnect.Posts.Common.Tests.Features.Users.Utilities;

namespace InstaConnect.PostLikes.Common.Tests.Features.PostLikes.Utilities.Builders.GetAllApiRequest;

public class GetAllPostLikesApiRequestBuilder
{
    private readonly ObjectBuilder<GetAllPostLikesApiRequest> _objectBuilder;

    public GetAllPostLikesApiRequestBuilder(ObjectBuilder<GetAllPostLikesApiRequest> objectBuilder)
    {
        _objectBuilder = objectBuilder;

        WithId(PostDataFaker.GetId());
        WithUserId(UserDataFaker.GetId());
        WithUserName(UserDataFaker.GetName());
        WithPage(PostLikeDataFaker.GetPage());
        WithPageSize(PostLikeDataFaker.GetPageSize());
        WithSortOrder(DataFaker.GetSortOrder());
        WithSortProperty(PostLikeDataFaker.GetSortProperty());
    }

    public GetAllPostLikesApiRequestBuilder(ObjectBuilder<GetAllPostLikesApiRequest> objectBuilder, PostLike postLike, User user)
    {
        _objectBuilder = objectBuilder;

        WithId(postLike.Id);
        WithUserId(user.Id);
        WithUserName(user.Name);
        WithPage(PostLikeDataFaker.GetPage());
        WithPageSize(PostLikeDataFaker.GetPageSize());
        WithSortOrder(DataFaker.GetSortOrder());
        WithSortProperty(PostLikeDataFaker.GetSortProperty());
    }

    public GetAllPostLikesApiRequestBuilder WithId(string id, IStringTransformer? transformer = null)
    {
        _objectBuilder.With(p => p.Filter.Id, id, transformer);

        return this;
    }

    public GetAllPostLikesApiRequestBuilder WithUserId(string userId, IStringTransformer? transformer = null)
    {
        _objectBuilder.With(p => p.Filter.UserId, userId, transformer);

        return this;
    }

    public GetAllPostLikesApiRequestBuilder WithUserName(string userName, IStringTransformer? transformer = null)
    {
        _objectBuilder.With(p => p.Filter.UserName, userName, transformer);

        return this;
    }

    public GetAllPostLikesApiRequestBuilder WithPage(int page, IIntTransformer? transformer = null)
    {
        _objectBuilder.With(p => p.Pagination.Page, page, transformer);

        return this;
    }

    public GetAllPostLikesApiRequestBuilder WithPageSize(int pageSize, IIntTransformer? transformer = null)
    {
        _objectBuilder.With(p => p.Pagination.PageSize, pageSize, transformer);

        return this;
    }

    public GetAllPostLikesApiRequestBuilder WithSortOrder(SortOrder order, IEnumTransformer<SortOrder>? transformer = null)
    {
        _objectBuilder.With(p => p.Sorting.Order, order, transformer);

        return this;
    }

    public GetAllPostLikesApiRequestBuilder WithSortProperty(PostLikeSortProperty property, IEnumTransformer<PostLikeSortProperty>? transformer = null)
    {
        _objectBuilder.With(p => p.Sorting.Property, property, transformer);

        return this;
    }

    public GetAllPostLikesApiRequest Create()
    {
        return _objectBuilder.Create();
    }
}
