using InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.Requests;

namespace InstaConnect.Posts.Presentation.Tests.Features.PostCommentLikes.Builders;

public class GetAllPostCommentLikesApiRequestBuilder
{
    private readonly ObjectBuilder<GetAllPostCommentLikesApiRequest> _objectBuilder;

    public GetAllPostCommentLikesApiRequestBuilder(ObjectBuilder<GetAllPostCommentLikesApiRequest> objectBuilder, PostCommentLike postCommentLike, User user)
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

    public GetAllPostCommentLikesApiRequestBuilder WithId(string id, IStringTransformer? transformer = null)
    {
        _objectBuilder.WithString(p => p.Filter.Id, id, transformer);

        return this;
    }

    public GetAllPostCommentLikesApiRequestBuilder WithCommentId(string commentId, IStringTransformer? transformer = null)
    {
        _objectBuilder.WithString(p => p.Filter.CommentId, commentId, transformer);

        return this;
    }

    public GetAllPostCommentLikesApiRequestBuilder WithUserName(string userName, IStringTransformer? transformer = null)
    {
        _objectBuilder.WithString(p => p.Filter.UserName, userName, transformer);

        return this;
    }

    public GetAllPostCommentLikesApiRequestBuilder WithPage(int page, IIntTransformer? transformer = null)
    {
        _objectBuilder.WithInt(p => p.Pagination.Page, page, transformer);

        return this;
    }

    public GetAllPostCommentLikesApiRequestBuilder WithPageSize(int pageSize, IIntTransformer? transformer = null)
    {
        _objectBuilder.WithInt(p => p.Pagination.PageSize, pageSize, transformer);

        return this;
    }

    public GetAllPostCommentLikesApiRequestBuilder WithSortOrder(SortOrder order, IEnumTransformer<SortOrder>? transformer = null)
    {
        _objectBuilder.WithEnum(p => p.Sorting.Order, order, transformer);

        return this;
    }

    public GetAllPostCommentLikesApiRequestBuilder WithSortProperty(PostCommentLikeSortProperty property, IEnumTransformer<PostCommentLikeSortProperty>? transformer = null)
    {
        _objectBuilder.WithEnum(p => p.Sorting.Property, property, transformer);

        return this;
    }

    public GetAllPostCommentLikesApiRequest Build()
    {
        return _objectBuilder.Build();
    }
}
