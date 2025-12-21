using InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.Requests;

namespace InstaConnect.Posts.Presentation.Tests.Features.PostCommentLikes.Builders;

public class GetAllPostCommentLikesApiRequestBuilder
{
    private string _id;
    private string _commentId;
    private string _userName;
    private int _page;
    private int _pageSize;
    private CommonSortOrder _sortOrder;
    private PostCommentLikeSortProperty _sortProperty;

    public GetAllPostCommentLikesApiRequestBuilder(PostCommentLike postCommentLike)
    {
        _id = postCommentLike.Id.CommentId.Id.Id;
        _commentId = postCommentLike.Id.CommentId.CommentId;
        _userName = DataFaker.GetPrefixString(postCommentLike.User!.Name.Value);
        _page = PostCommentLikeDataFaker.GetPage();
        _pageSize = PostCommentLikeDataFaker.GetPageSize();
        _sortOrder = DataFaker.GetSortOrder();
        _sortProperty = PostCommentLikeDataFaker.GetSortProperty();
    }

    public GetAllPostCommentLikesApiRequestBuilder WithId(Post post, IStringTransformer? transformer = null)
    {
        _id = transformer.TryTransform(post.Id.Id);

        return this;
    }

    public GetAllPostCommentLikesApiRequestBuilder WithId(IStringTransformer transformer)
    {
        _id = transformer.Transform(_id);

        return this;
    }

    public GetAllPostCommentLikesApiRequestBuilder WithCommentId(PostComment postComment, IStringTransformer? transformer = null)
    {
        _commentId = transformer.TryTransform(postComment.Id.CommentId);

        return this;
    }

    public GetAllPostCommentLikesApiRequestBuilder WithCommentId(IStringTransformer transformer)
    {
        _commentId = transformer.Transform(_commentId);

        return this;
    }

    public GetAllPostCommentLikesApiRequestBuilder WithUserName(IStringTransformer transformer)
    {
        _userName = transformer.Transform(_userName);

        return this;
    }

    public GetAllPostCommentLikesApiRequestBuilder WithPage(IIntTransformer transformer)
    {
        _page = transformer.Transform(_page);

        return this;
    }

    public GetAllPostCommentLikesApiRequestBuilder WithPageSize(IIntTransformer transformer)
    {
        _pageSize = transformer.Transform(_pageSize);

        return this;
    }

    public GetAllPostCommentLikesApiRequestBuilder WithSortOrder(IEnumTransformer<CommonSortOrder> transformer)
    {
        _sortOrder = transformer.Transform(_sortOrder);

        return this;
    }

    public GetAllPostCommentLikesApiRequestBuilder WithSortProperty(IEnumTransformer<PostCommentLikeSortProperty> transformer)
    {
        _sortProperty = transformer.Transform(_sortProperty);

        return this;
    }

    public GetAllPostCommentLikesApiRequest Build()
    {
        return new(_id, _commentId, _userName, _sortOrder, _sortProperty, _page, _pageSize);
    }
}
