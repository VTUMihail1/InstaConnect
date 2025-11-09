using InstaConnect.Posts.Domain.Features.PostLikes.Models.Requests;

namespace InstaConnect.Posts.Presentation.Tests.Features.PostLikes.Builders;

public class GetAllPostLikesApiRequestBuilder
{
    private readonly ObjectBuilder<GetAllPostLikesApiRequest> _objectBuilder;

    public GetAllPostLikesApiRequestBuilder(ObjectBuilder<GetAllPostLikesApiRequest> objectBuilder, PostLike postLike, User user)
    {
        _objectBuilder = objectBuilder;

        WithId(postLike.Id);
        WithUserName(user.Name);
        WithPage(PostLikeDataFaker.GetPage());
        WithPageSize(PostLikeDataFaker.GetPageSize());
        WithSortOrder(DataFaker.GetSortOrder());
        WithSortProperty(PostLikeDataFaker.GetSortProperty());
    }

    public GetAllPostLikesApiRequestBuilder WithId(string id, IStringTransformer? transformer = null)
    {
        _objectBuilder.WithString(p => p.Filter.Id, id, transformer);

        return this;
    }

    public GetAllPostLikesApiRequestBuilder WithUserName(string userName, IStringTransformer? transformer = null)
    {
        _objectBuilder.WithString(p => p.Filter.UserName, userName, transformer);

        return this;
    }

    public GetAllPostLikesApiRequestBuilder WithPage(int page, IIntTransformer? transformer = null)
    {
        _objectBuilder.WithInt(p => p.Pagination.Page, page, transformer);

        return this;
    }

    public GetAllPostLikesApiRequestBuilder WithPageSize(int pageSize, IIntTransformer? transformer = null)
    {
        _objectBuilder.WithInt(p => p.Pagination.PageSize, pageSize, transformer);

        return this;
    }

    public GetAllPostLikesApiRequestBuilder WithSortOrder(SortOrder order, IEnumTransformer<SortOrder>? transformer = null)
    {
        _objectBuilder.WithEnum(p => p.Sorting.Order, order, transformer);

        return this;
    }

    public GetAllPostLikesApiRequestBuilder WithSortProperty(PostLikeSortProperty property, IEnumTransformer<PostLikeSortProperty>? transformer = null)
    {
        _objectBuilder.WithEnum(p => p.Sorting.Property, property, transformer);

        return this;
    }

    public GetAllPostLikesApiRequest Build()
    {
        return _objectBuilder.Build();
    }
}
