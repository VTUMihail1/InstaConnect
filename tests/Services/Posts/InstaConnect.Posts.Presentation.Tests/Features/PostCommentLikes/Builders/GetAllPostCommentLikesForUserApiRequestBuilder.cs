using InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.Requests;

namespace InstaConnect.Posts.Presentation.Tests.Features.PostCommentLikes.Builders;

public class GetAllPostCommentLikesForUserApiRequestBuilder
{
    private string _userId;
    private string _currentUserId;
    private int _page;
    private int _pageSize;
    private CommonSortOrder _sortOrder;
    private PostCommentLikesSortTerm _sortTerm;

    public GetAllPostCommentLikesForUserApiRequestBuilder(PostCommentLike postCommentLike)
    {
        _userId = postCommentLike.Id.UserId.Id;
        _currentUserId = postCommentLike.Id.UserId.Id;
        _page = PostCommentLikeDataFaker.GetPage();
        _pageSize = PostCommentLikeDataFaker.GetPageSize();
        _sortOrder = DataFaker.GetSortOrder();
        _sortTerm = PostCommentLikeDataFaker.GetSortTerm();
    }

    public GetAllPostCommentLikesForUserApiRequestBuilder WithUserId(User user, IStringTransformer? transformer = null)
    {
        _userId = transformer.TryTransform(user.Id.Id);

        return this;
    }

    public GetAllPostCommentLikesForUserApiRequestBuilder WithUserId(IStringTransformer transformer)
    {
        _userId = transformer.Transform(_userId);

        return this;
    }

    public GetAllPostCommentLikesForUserApiRequestBuilder WithCurrentUserId(User user, IStringTransformer? transformer = null)
    {
        _currentUserId = transformer.TryTransform(user.Id.Id);

        return this;
    }

    public GetAllPostCommentLikesForUserApiRequestBuilder WithCurrentUserId(IStringTransformer transformer)
    {
        _currentUserId = transformer.Transform(_currentUserId);

        return this;
    }

    public GetAllPostCommentLikesForUserApiRequestBuilder WithPage(IIntTransformer transformer)
    {
        _page = transformer.Transform(_page);

        return this;
    }

    public GetAllPostCommentLikesForUserApiRequestBuilder WithPageSize(IIntTransformer transformer)
    {
        _pageSize = transformer.Transform(_pageSize);

        return this;
    }

    public GetAllPostCommentLikesForUserApiRequestBuilder WithSortOrder(IEnumTransformer<CommonSortOrder> transformer)
    {
        _sortOrder = transformer.Transform(_sortOrder);

        return this;
    }

    public GetAllPostCommentLikesForUserApiRequestBuilder WithSortTerm(IEnumTransformer<PostCommentLikesSortTerm> transformer)
    {
        _sortTerm = transformer.Transform(_sortTerm);

        return this;
    }

    public GetAllPostCommentLikesForUserApiRequest Build()
    {
        return new(_userId, _currentUserId, _sortOrder, _sortTerm, _page, _pageSize);
    }
}
