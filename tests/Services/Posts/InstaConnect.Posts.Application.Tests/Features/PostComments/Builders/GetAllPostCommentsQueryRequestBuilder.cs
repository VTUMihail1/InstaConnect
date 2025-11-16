using InstaConnect.Common.Tests.DataAttributes.Base;

namespace InstaConnect.Posts.Application.Tests.Features.PostComments.Builders;

public class GetAllPostCommentsQueryRequestBuilder
{
    private string _id;
    private string _userId;
    private string _userName;
    private int _page;
    private int _pageSize;
    private CommonSortOrder _sortOrder;
    private PostCommentSortProperty _sortProperty;

    public GetAllPostCommentsQueryRequestBuilder(PostComment postComment, User user)
    {
        _id = postComment.Id;
        _userId = user.Id;
        _userName = user.Name;
        _page = PostCommentDataFaker.GetPage();
        _pageSize = PostCommentDataFaker.GetPageSize();
        _sortOrder = DataFaker.GetSortOrder();
        _sortProperty = PostCommentDataFaker.GetSortProperty();
    }

    public GetAllPostCommentsQueryRequestBuilder WithId(string id, IStringTransformer? transformer = null)
    {
        _id = transformer.TryTransform(id);

        return this;
    }

    public GetAllPostCommentsQueryRequestBuilder WithUserId(string userId, IStringTransformer? transformer = null)
    {
        _userId = transformer.TryTransform(userId);

        return this;
    }

    public GetAllPostCommentsQueryRequestBuilder WithUserName(string userName, IStringTransformer? transformer = null)
    {
        _userName = transformer.TryTransform(userName);

        return this;
    }

    public GetAllPostCommentsQueryRequestBuilder WithPage(int page, IIntTransformer? transformer = null)
    {
        _page = transformer.TryTransform(page);

        return this;
    }

    public GetAllPostCommentsQueryRequestBuilder WithPageSize(int pageSize, IIntTransformer? transformer = null)
    {
        _pageSize = transformer.TryTransform(pageSize);

        return this;
    }

    public GetAllPostCommentsQueryRequestBuilder WithSortOrder(CommonSortOrder order, IEnumTransformer<CommonSortOrder>? transformer = null)
    {
        _sortOrder = transformer.TryTransform(order);

        return this;
    }

    public GetAllPostCommentsQueryRequestBuilder WithSortProperty(PostCommentSortProperty property, IEnumTransformer<PostCommentSortProperty>? transformer = null)
    {
        _sortProperty = transformer.TryTransform(property);

        return this;
    }

    public GetAllPostCommentsQueryRequest Build()
    {
        return new(
            new(_id, _userId, _userName),
            new(_sortOrder, _sortProperty),
            new(_page, _pageSize)
        );
    }
}
