namespace InstaConnect.Posts.Application.Tests.Features.PostComments.Builders;

public class GetAllPostCommentsQueryRequestBuilder
{
    private readonly ObjectBuilder<GetAllPostCommentsQueryRequest> _objectBuilder;

    public GetAllPostCommentsQueryRequestBuilder(ObjectBuilder<GetAllPostCommentsQueryRequest> objectBuilder, PostComment postComment, User user)
    {
        _objectBuilder = objectBuilder;

        WithId(postComment.Id);
        WithUserId(user.Id);
        WithUserName(user.Name);
        WithPage(PostCommentDataFaker.GetPage());
        WithPageSize(PostCommentDataFaker.GetPageSize());
        WithSortOrder(DataFaker.GetSortOrder());
        WithSortProperty(PostCommentDataFaker.GetSortProperty());
    }

    public GetAllPostCommentsQueryRequestBuilder WithId(string id, IStringTransformer? transformer = null)
    {
        _objectBuilder.WithString(p => p.Filter.Id, id, transformer);

        return this;
    }

    public GetAllPostCommentsQueryRequestBuilder WithUserId(string userId, IStringTransformer? transformer = null)
    {
        _objectBuilder.WithString(p => p.Filter.UserId, userId, transformer);

        return this;
    }

    public GetAllPostCommentsQueryRequestBuilder WithUserName(string userName, IStringTransformer? transformer = null)
    {
        _objectBuilder.WithString(p => p.Filter.UserName, userName, transformer);

        return this;
    }

    public GetAllPostCommentsQueryRequestBuilder WithPage(int page, IIntTransformer? transformer = null)
    {
        _objectBuilder.WithInt(p => p.Pagination.Page, page, transformer);

        return this;
    }

    public GetAllPostCommentsQueryRequestBuilder WithPageSize(int pageSize, IIntTransformer? transformer = null)
    {
        _objectBuilder.WithInt(p => p.Pagination.PageSize, pageSize, transformer);

        return this;
    }

    public GetAllPostCommentsQueryRequestBuilder WithSortOrder(SortOrder order, IEnumTransformer<SortOrder>? transformer = null)
    {
        _objectBuilder.WithEnum(p => p.Sorting.Order, order, transformer);

        return this;
    }

    public GetAllPostCommentsQueryRequestBuilder WithSortProperty(PostCommentSortProperty property, IEnumTransformer<PostCommentSortProperty>? transformer = null)
    {
        _objectBuilder.WithEnum(p => p.Sorting.Property, property, transformer);

        return this;
    }

    public GetAllPostCommentsQueryRequest Build()
    {
        return _objectBuilder.Build();
    }
}
