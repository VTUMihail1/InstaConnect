using InstaConnect.Posts.Domain.Features.PostLikes.Models.Requests;

namespace InstaConnect.Posts.Presentation.Tests.Features.PostLikes.Builders;

public class GetAllPostLikesApiRequestBuilder
{
    private string _id;
    private string _userName;
    private int _page;
    private int _pageSize;
    private CommonSortOrder _sortOrder;
    private PostLikeSortProperty _sortProperty;

    public GetAllPostLikesApiRequestBuilder(PostLike postLike)
    {
        _id = postLike.Id.Id.Id;
        _userName = DataFaker.GetPrefixString(postLike.User!.Name.Value);
        _page = PostLikeDataFaker.GetPage();
        _pageSize = PostLikeDataFaker.GetPageSize();
        _sortOrder = DataFaker.GetSortOrder();
        _sortProperty = PostLikeDataFaker.GetSortProperty();
    }

    public GetAllPostLikesApiRequestBuilder WithId(Post post, IStringTransformer? transformer = null)
    {
        _id = transformer.TryTransform(post.Id.Id);

        return this;
    }

    public GetAllPostLikesApiRequestBuilder WithId(IStringTransformer transformer)
    {
        _id = transformer.Transform(_id);

        return this;
    }

    public GetAllPostLikesApiRequestBuilder WithUserName(IStringTransformer transformer)
    {
        _userName = transformer.Transform(_userName);

        return this;
    }

    public GetAllPostLikesApiRequestBuilder WithPage(IIntTransformer transformer)
    {
        _page = transformer.Transform(_page);

        return this;
    }

    public GetAllPostLikesApiRequestBuilder WithPageSize(IIntTransformer transformer)
    {
        _pageSize = transformer.Transform(_pageSize);

        return this;
    }

    public GetAllPostLikesApiRequestBuilder WithSortOrder(IEnumTransformer<CommonSortOrder> transformer)
    {
        _sortOrder = transformer.Transform(_sortOrder);

        return this;
    }

    public GetAllPostLikesApiRequestBuilder WithSortProperty(IEnumTransformer<PostLikeSortProperty> transformer)
    {
        _sortProperty = transformer.Transform(_sortProperty);

        return this;
    }

    public GetAllPostLikesApiRequest Build()
    {
        return new(_id, _userName, _sortOrder, _sortProperty, _page, _pageSize);
    }
}
