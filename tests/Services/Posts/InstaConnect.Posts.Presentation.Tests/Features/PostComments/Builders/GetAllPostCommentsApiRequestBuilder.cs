using InstaConnect.Posts.Domain.Features.PostComments.Models.Requests;

namespace InstaConnect.Posts.Presentation.Tests.Features.PostComments.Builders;

public class GetAllPostCommentsApiRequestBuilder
{
    private string _id;
    private string _userId;
    private string _userName;
    private int _page;
    private int _pageSize;
    private CommonSortOrder _sortOrder;
    private PostCommentSortProperty _sortProperty;

    public GetAllPostCommentsApiRequestBuilder(PostComment postComment, User user)
    {
        _id = postComment.Id.Id.Id;
        _userId = user.Id.Id;
        _userName = user.Name.Value;
        _page = PostCommentDataFaker.GetPage();
        _pageSize = PostCommentDataFaker.GetPageSize();
        _sortOrder = DataFaker.GetSortOrder();
        _sortProperty = PostCommentDataFaker.GetSortProperty();
    }

    public GetAllPostCommentsApiRequestBuilder WithId(Post post, IStringTransformer? transformer = null)
    {
        _id = transformer.TryTransform(post.Id.Id);

        return this;
    }

    public GetAllPostCommentsApiRequestBuilder WithId(IStringTransformer transformer)
    {
        _id = transformer.Transform(_id);

        return this;
    }

    public GetAllPostCommentsApiRequestBuilder WithUserId(IStringTransformer transformer)
    {
        _userId = transformer.Transform(_userId);

        return this;
    }

    public GetAllPostCommentsApiRequestBuilder WithUserName(IStringTransformer transformer)
    {
        _userName = transformer.Transform(_userName);

        return this;
    }

    public GetAllPostCommentsApiRequestBuilder WithPage(IIntTransformer transformer)
    {
        _page = transformer.Transform(_page);

        return this;
    }

    public GetAllPostCommentsApiRequestBuilder WithPageSize(IIntTransformer transformer)
    {
        _pageSize = transformer.Transform(_pageSize);

        return this;
    }

    public GetAllPostCommentsApiRequestBuilder WithSortOrder(IEnumTransformer<CommonSortOrder> transformer)
    {
        _sortOrder = transformer.Transform(_sortOrder);

        return this;
    }

    public GetAllPostCommentsApiRequestBuilder WithSortProperty(IEnumTransformer<PostCommentSortProperty> transformer)
    {
        _sortProperty = transformer.Transform(_sortProperty);

        return this;
    }

    public GetAllPostCommentsApiRequest Build()
    {
        return new(_id, _userId, _userName, _sortOrder, _sortProperty, _page, _pageSize);
    }
}
