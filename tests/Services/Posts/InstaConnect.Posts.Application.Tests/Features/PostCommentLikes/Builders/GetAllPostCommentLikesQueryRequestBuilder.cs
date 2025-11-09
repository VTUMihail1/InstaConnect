namespace InstaConnect.Posts.Application.Tests.Features.PostCommentLikes.Builders;

public class GetAllPostCommentLikesQueryRequestBuilder
{
    private readonly ObjectBuilder<GetAllPostCommentLikesQueryRequest> _objectBuilder;

    public GetAllPostCommentLikesQueryRequestBuilder(ObjectBuilder<GetAllPostCommentLikesQueryRequest> objectBuilder, PostCommentLike postCommentLike, User user)
    {
        _objectBuilder = objectBuilder;

        WithId(postCommentLike.Id);
        WithCommentId(postCommentLike.CommentId);
        WithUserName(user.Name);
        WithPage(PostCommentLikeDataFaker.GetPage());
        WithPageSize(PostCommentLikeDataFaker.GetPageSize());
        WithSortOrder(DataFaker.GetSortOrder());
        WithSortProperty(PostCommentLikeDataFaker.GetSortProperty());
    }

    public GetAllPostCommentLikesQueryRequestBuilder WithId(string id, IStringTransformer? transformer = null)
    {
        _objectBuilder.WithString(p => p.Filter.Id, id, transformer);

        return this;
    }

    public GetAllPostCommentLikesQueryRequestBuilder WithCommentId(string commentId, IStringTransformer? transformer = null)
    {
        _objectBuilder.WithString(p => p.Filter.CommentId, commentId, transformer);

        return this;
    }

    public GetAllPostCommentLikesQueryRequestBuilder WithUserName(string userName, IStringTransformer? transformer = null)
    {
        _objectBuilder.WithString(p => p.Filter.UserName, userName, transformer);

        return this;
    }

    public GetAllPostCommentLikesQueryRequestBuilder WithPage(int page, IIntTransformer? transformer = null)
    {
        _objectBuilder.WithInt(p => p.Pagination.Page, page, transformer);

        return this;
    }

    public GetAllPostCommentLikesQueryRequestBuilder WithPageSize(int pageSize, IIntTransformer? transformer = null)
    {
        _objectBuilder.WithInt(p => p.Pagination.PageSize, pageSize, transformer);

        return this;
    }

    public GetAllPostCommentLikesQueryRequestBuilder WithSortOrder(SortOrder order, IEnumTransformer<SortOrder>? transformer = null)
    {
        _objectBuilder.WithEnum(p => p.Sorting.Order, order, transformer);

        return this;
    }

    public GetAllPostCommentLikesQueryRequestBuilder WithSortProperty(PostCommentLikeSortProperty property, IEnumTransformer<PostCommentLikeSortProperty>? transformer = null)
    {
        _objectBuilder.WithEnum(p => p.Sorting.Property, property, transformer);

        return this;
    }

    public GetAllPostCommentLikesQueryRequest Build()
    {
        return _objectBuilder.Build();
    }
}
