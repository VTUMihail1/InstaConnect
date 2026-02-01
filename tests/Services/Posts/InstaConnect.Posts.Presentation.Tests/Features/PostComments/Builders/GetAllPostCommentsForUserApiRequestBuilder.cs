using InstaConnect.Posts.Domain.Features.PostComments.Models.Requests;

namespace InstaConnect.Posts.Presentation.Tests.Features.PostComments.Builders;

public class GetAllPostCommentsForUserApiRequestBuilder
{
    private string _userId;
    private string _currentUserId;
    private int _page;
    private int _pageSize;
    private CommonSortOrder _sortOrder;
    private PostCommentsSortTerm _sortTerm;

    public GetAllPostCommentsForUserApiRequestBuilder(PostComment postComment)
    {
        _userId = postComment.UserId.Id;
        _currentUserId = postComment.UserId.Id;
        _page = PostCommentDataFaker.GetPage();
        _pageSize = PostCommentDataFaker.GetPageSize();
        _sortOrder = DataFaker.GetSortOrder();
        _sortTerm = PostCommentDataFaker.GetSortTerm();
    }

    public GetAllPostCommentsForUserApiRequestBuilder WithUserId(User user, IStringTransformer? transformer = null)
    {
        _userId = transformer.TryTransform(user.Id.Id);

        return this;
    }

    public GetAllPostCommentsForUserApiRequestBuilder WithUserId(IStringTransformer transformer)
    {
        _userId = transformer.Transform(_userId);

        return this;
    }

    public GetAllPostCommentsForUserApiRequestBuilder WithCurrentUserId(User user, IStringTransformer? transformer = null)
    {
        _currentUserId = transformer.TryTransform(user.Id.Id);

        return this;
    }

    public GetAllPostCommentsForUserApiRequestBuilder WithCurrentUserId(IStringTransformer transformer)
    {
        _currentUserId = transformer.Transform(_currentUserId);

        return this;
    }

    public GetAllPostCommentsForUserApiRequestBuilder WithPage(IIntTransformer transformer)
    {
        _page = transformer.Transform(_page);

        return this;
    }

    public GetAllPostCommentsForUserApiRequestBuilder WithPageSize(IIntTransformer transformer)
    {
        _pageSize = transformer.Transform(_pageSize);

        return this;
    }

    public GetAllPostCommentsForUserApiRequestBuilder WithSortOrder(IEnumTransformer<CommonSortOrder> transformer)
    {
        _sortOrder = transformer.Transform(_sortOrder);

        return this;
    }

    public GetAllPostCommentsForUserApiRequestBuilder WithSortTerm(IEnumTransformer<PostCommentsSortTerm> transformer)
    {
        _sortTerm = transformer.Transform(_sortTerm);

        return this;
    }

    public GetAllPostCommentsForUserApiRequest Build()
    {
        return new(_userId, _currentUserId, _sortOrder, _sortTerm, _page, _pageSize);
    }
}
