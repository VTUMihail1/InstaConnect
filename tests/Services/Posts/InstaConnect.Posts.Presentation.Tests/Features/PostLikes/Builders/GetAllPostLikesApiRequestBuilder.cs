using InstaConnect.Posts.Domain.Features.PostLikes.Models.Requests;

namespace InstaConnect.Posts.Presentation.Tests.Features.PostLikes.Builders;

public class GetAllPostLikesApiRequestBuilder
{
    private string _id;
    private string _userName;
    private int _page;
    private int _pageSize;
    private SortOrder _sortOrder;
    private PostLikeSortProperty _sortProperty;

    public GetAllPostLikesApiRequestBuilder(PostLike postLike, User user)
    {
        _id = postLike.Id;
        _userName = user.Name;
        _page = PostLikeDataFaker.GetPage();
        _pageSize = PostLikeDataFaker.GetPageSize();
        _sortOrder = DataFaker.GetSortOrder();
        _sortProperty = PostLikeDataFaker.GetSortProperty();
    }

    public GetAllPostLikesApiRequestBuilder WithId(string id, IStringTransformer? transformer = null)
    {
        _id = transformer.TryTransform(id);

        return this;
    }

    public GetAllPostLikesApiRequestBuilder WithUserName(string userName, IStringTransformer? transformer = null)
    {
        _userName = transformer.TryTransform(userName);

        return this;
    }

    public GetAllPostLikesApiRequestBuilder WithPage(int page, IIntTransformer? transformer = null)
    {
        _page = transformer.TryTransform(page);

        return this;
    }

    public GetAllPostLikesApiRequestBuilder WithPageSize(int pageSize, IIntTransformer? transformer = null)
    {
        _pageSize = transformer.TryTransform(pageSize);

        return this;
    }

    public GetAllPostLikesApiRequestBuilder WithSortOrder(SortOrder order, IEnumTransformer<SortOrder>? transformer = null)
    {
        _sortOrder = transformer.TryTransform(order);

        return this;
    }

    public GetAllPostLikesApiRequestBuilder WithSortProperty(PostLikeSortProperty property, IEnumTransformer<PostLikeSortProperty>? transformer = null)
    {
        _sortProperty = transformer.TryTransform(property);

        return this;
    }

    public GetAllPostLikesApiRequest Build()
    {
        return new(
            new(_id, _userName),
            new(_sortOrder, _sortProperty),
            new(_page, _pageSize)
        );
    }
}
