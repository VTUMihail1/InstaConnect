namespace InstaConnect.Posts.Application.Tests.Features.PostLikes.Builders;

public class GetAllPostLikesQueryRequestBuilder
{
    private readonly ObjectBuilder<GetAllPostLikesQueryRequest> _objectBuilder;

    public GetAllPostLikesQueryRequestBuilder(ObjectBuilder<GetAllPostLikesQueryRequest> objectBuilder, PostLike postLike, User user)
    {
        _objectBuilder = objectBuilder;

        WithId(postLike.Id);
        WithUserName(user.Name);
        WithPage(PostLikeDataFaker.GetPage());
        WithPageSize(PostLikeDataFaker.GetPageSize());
        WithSortOrder(DataFaker.GetSortOrder());
        WithSortProperty(PostLikeDataFaker.GetSortProperty());
    }

    public GetAllPostLikesQueryRequestBuilder WithId(string id, IStringTransformer? transformer = null)
    {
        _objectBuilder.WithString(p => p.Filter.Id, id, transformer);

        return this;
    }

    public GetAllPostLikesQueryRequestBuilder WithUserName(string userName, IStringTransformer? transformer = null)
    {
        _objectBuilder.WithString(p => p.Filter.UserName, userName, transformer);

        return this;
    }

    public GetAllPostLikesQueryRequestBuilder WithPage(int page, IIntTransformer? transformer = null)
    {
        _objectBuilder.WithInt(p => p.Pagination.Page, page, transformer);

        return this;
    }

    public GetAllPostLikesQueryRequestBuilder WithPageSize(int pageSize, IIntTransformer? transformer = null)
    {
        _objectBuilder.WithInt(p => p.Pagination.PageSize, pageSize, transformer);

        return this;
    }

    public GetAllPostLikesQueryRequestBuilder WithSortOrder(SortOrder order, IEnumTransformer<SortOrder>? transformer = null)
    {
        _objectBuilder.WithEnum(p => p.Sorting.Order, order, transformer);

        return this;
    }

    public GetAllPostLikesQueryRequestBuilder WithSortProperty(PostLikeSortProperty property, IEnumTransformer<PostLikeSortProperty>? transformer = null)
    {
        _objectBuilder.WithEnum(p => p.Sorting.Property, property, transformer);

        return this;
    }

    public GetAllPostLikesQueryRequest Build()
    {
        return _objectBuilder.Build();
    }
}
