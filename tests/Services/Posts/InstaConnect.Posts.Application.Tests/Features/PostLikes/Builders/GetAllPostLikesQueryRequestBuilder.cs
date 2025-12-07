using InstaConnect.Common.Tests.DataAttributes.Base;

namespace InstaConnect.Posts.Application.Tests.Features.PostLikes.Builders;

public class GetAllPostLikesQueryRequestBuilder
{
    private string _id;
    private string _userName;
    private int _page;
    private int _pageSize;
    private CommonSortOrder _sortOrder;
    private PostLikeSortProperty _sortProperty;

    public GetAllPostLikesQueryRequestBuilder(PostLike postLike, User user)
    {
        _id = postLike.Id.Id.Id;
        _userName = user.Name.Value;
        _page = PostLikeDataFaker.GetPage();
        _pageSize = PostLikeDataFaker.GetPageSize();
        _sortOrder = DataFaker.GetSortOrder();
        _sortProperty = PostLikeDataFaker.GetSortProperty();
    }

    public GetAllPostLikesQueryRequestBuilder WithId(Post post, IStringTransformer? transformer = null)
    {
        _id = transformer.TryTransform(post.Id.Id);

        return this;
    }

    public GetAllPostLikesQueryRequestBuilder WithId(IStringTransformer transformer)
    {
        _id = transformer.Transform(_id);

        return this;
    }

    public GetAllPostLikesQueryRequestBuilder WithUserName(IStringTransformer transformer)
    {
        _userName = transformer.Transform(_userName);

        return this;
    }

    public GetAllPostLikesQueryRequestBuilder WithPage(IIntTransformer transformer)
    {
        _page = transformer.Transform(_page);

        return this;
    }

    public GetAllPostLikesQueryRequestBuilder WithPageSize(IIntTransformer transformer)
    {
        _pageSize = transformer.Transform(_pageSize);

        return this;
    }

    public GetAllPostLikesQueryRequestBuilder WithSortOrder(IEnumTransformer<CommonSortOrder> transformer)
    {
        _sortOrder = transformer.Transform(_sortOrder);

        return this;
    }

    public GetAllPostLikesQueryRequestBuilder WithSortProperty(IEnumTransformer<PostLikeSortProperty> transformer)
    {
        _sortProperty = transformer.Transform(_sortProperty);

        return this;
    }

    public GetAllPostLikesQueryRequest Build()
    {
        return new(_id, _userName, _sortOrder, _sortProperty, _page, _pageSize);
    }
}
