using InstaConnect.Posts.Domain.Features.PostLikes.Models.Requests;

namespace InstaConnect.Posts.Presentation.Tests.Features.PostLikes.Builders;

public class GetAllPostLikesApiRequestBuilder
{
    private string _id;
    private string _userName;
    private string _currentUserId;
    private int _page;
    private int _pageSize;
    private CommonSortOrder _sortOrder;
    private PostLikesSortTerm _sortTerm;

    public GetAllPostLikesApiRequestBuilder(PostLike postLike)
    {
        _id = postLike.Id.Id.Id;
        _userName = DataFaker.GetPrefixString(postLike.User!.Name.Value);
        _currentUserId = postLike.Id.UserId.Id;
        _page = PostLikeDataFaker.GetPage();
        _pageSize = PostLikeDataFaker.GetPageSize();
        _sortOrder = DataFaker.GetSortOrder();
        _sortTerm = PostLikeDataFaker.GetSortTerm();
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

    public GetAllPostLikesApiRequestBuilder WithCurrentUserId(User user, IStringTransformer? transformer = null)
    {
        _currentUserId = transformer.TryTransform(user.Id.Id);

        return this;
    }

    public GetAllPostLikesApiRequestBuilder WithCurrentUserId(IStringTransformer transformer)
    {
        _currentUserId = transformer.Transform(_currentUserId);

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

    public GetAllPostLikesApiRequestBuilder WithSortTerm(IEnumTransformer<PostLikesSortTerm> transformer)
    {
        _sortTerm = transformer.Transform(_sortTerm);

        return this;
    }

    public GetAllPostLikesApiRequest Build()
    {
        return new(_id, _userName, _currentUserId, _sortOrder, _sortTerm, _page, _pageSize);
    }
}
