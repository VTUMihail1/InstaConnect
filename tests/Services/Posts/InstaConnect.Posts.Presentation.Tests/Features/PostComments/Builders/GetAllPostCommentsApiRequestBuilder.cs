using InstaConnect.Posts.Domain.Features.PostComments.Models.Requests;

namespace InstaConnect.Posts.Presentation.Tests.Features.PostComments.Builders;

public class GetAllPostCommentsApiRequestBuilder
{
    private readonly ObjectBuilder<GetAllPostCommentsApiRequest> _objectBuilder;

    public GetAllPostCommentsApiRequestBuilder(ObjectBuilder<GetAllPostCommentsApiRequest> objectBuilder, PostComment postComment, User user)
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

    public GetAllPostCommentsApiRequestBuilder WithId(string id, IStringTransformer? transformer = null)
    {
        _objectBuilder.WithString(p => p.Filter.Id, id, transformer);

        return this;
    }

    public GetAllPostCommentsApiRequestBuilder WithUserId(string userId, IStringTransformer? transformer = null)
    {
        _objectBuilder.WithString(p => p.Filter.UserId, userId, transformer);

        return this;
    }

    public GetAllPostCommentsApiRequestBuilder WithUserName(string userName, IStringTransformer? transformer = null)
    {
        _objectBuilder.WithString(p => p.Filter.UserName, userName, transformer);

        return this;
    }

    public GetAllPostCommentsApiRequestBuilder WithPage(int page, IIntTransformer? transformer = null)
    {
        _objectBuilder.WithInt(p => p.Pagination.Page, page, transformer);

        return this;
    }

    public GetAllPostCommentsApiRequestBuilder WithPageSize(int pageSize, IIntTransformer? transformer = null)
    {
        _objectBuilder.WithInt(p => p.Pagination.PageSize, pageSize, transformer);

        return this;
    }

    public GetAllPostCommentsApiRequestBuilder WithSortOrder(SortOrder order, IEnumTransformer<SortOrder>? transformer = null)
    {
        _objectBuilder.WithEnum(p => p.Sorting.Order, order, transformer);

        return this;
    }

    public GetAllPostCommentsApiRequestBuilder WithSortProperty(PostCommentSortProperty property, IEnumTransformer<PostCommentSortProperty>? transformer = null)
    {
        _objectBuilder.WithEnum(p => p.Sorting.Property, property, transformer);

        return this;
    }

    public GetAllPostCommentsApiRequest Build()
    {
        return _objectBuilder.Build();
    }
}
