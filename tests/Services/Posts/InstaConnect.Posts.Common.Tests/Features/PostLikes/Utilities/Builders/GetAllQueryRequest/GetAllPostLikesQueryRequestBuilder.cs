using InstaConnect.Common.Tests.Utilities;
using InstaConnect.Common.Tests.Utilities.Builders;
using InstaConnect.Common.Tests.Utilities.DataAttributes.Enums.Base;
using InstaConnect.Common.Tests.Utilities.DataAttributes.Ints.Base;
using InstaConnect.Common.Tests.Utilities.DataAttributes.Strings.Base;
using InstaConnect.PostLikes.Application.Features.PostLikes.Queries.GetAll;
using InstaConnect.PostLikes.Domain.Features.PostLikes.Models.Entities;
using InstaConnect.PostLikes.Domain.Features.PostLikes.Models.Requests;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities;
using InstaConnect.Posts.Common.Tests.Features.Users.Utilities;

namespace InstaConnect.PostLikes.Common.Tests.Features.PostLikes.Utilities.Builders.GetAllQueryRequest;

public class GetAllPostLikesQueryRequestBuilder
{
    private readonly ObjectBuilder<GetAllPostLikesQueryRequest> _objectBuilder;

    public GetAllPostLikesQueryRequestBuilder(ObjectBuilder<GetAllPostLikesQueryRequest> objectBuilder)
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

    public GetAllPostLikesQueryRequestBuilder(ObjectBuilder<GetAllPostLikesQueryRequest> objectBuilder, PostLike postLike, User user)
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

    public GetAllPostLikesQueryRequestBuilder WithId(string id, IStringTransformer? transformer = null)
    {
        _objectBuilder.With(p => p.Filter.Id, id, transformer);

        return this;
    }

    public GetAllPostLikesQueryRequestBuilder WithUserId(string userId, IStringTransformer? transformer = null)
    {
        _objectBuilder.With(p => p.Filter.UserId, userId, transformer);

        return this;
    }

    public GetAllPostLikesQueryRequestBuilder WithUserName(string userName, IStringTransformer? transformer = null)
    {
        _objectBuilder.With(p => p.Filter.UserName, userName, transformer);

        return this;
    }

    public GetAllPostLikesQueryRequestBuilder WithPage(int page, IIntTransformer? transformer = null)
    {
        _objectBuilder.With(p => p.Pagination.Page, page, transformer);

        return this;
    }

    public GetAllPostLikesQueryRequestBuilder WithPageSize(int pageSize, IIntTransformer? transformer = null)
    {
        _objectBuilder.With(p => p.Pagination.PageSize, pageSize, transformer);

        return this;
    }

    public GetAllPostLikesQueryRequestBuilder WithSortOrder(SortOrder order, IEnumTransformer<SortOrder>? transformer = null)
    {
        _objectBuilder.With(p => p.Sorting.Order, order, transformer);

        return this;
    }

    public GetAllPostLikesQueryRequestBuilder WithSortProperty(PostLikeSortProperty property, IEnumTransformer<PostLikeSortProperty>? transformer = null)
    {
        _objectBuilder.With(p => p.Sorting.Property, property, transformer);

        return this;
    }

    public GetAllPostLikesQueryRequest Create()
    {
        return _objectBuilder.Create();
    }
}
