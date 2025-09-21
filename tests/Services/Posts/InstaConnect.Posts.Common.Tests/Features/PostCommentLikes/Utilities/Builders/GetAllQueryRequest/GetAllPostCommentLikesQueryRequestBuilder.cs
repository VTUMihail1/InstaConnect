using InstaConnect.Common.Tests.Utilities;
using InstaConnect.Common.Tests.Utilities.Builders;
using InstaConnect.Common.Tests.Utilities.DataAttributes.Enums.Base;
using InstaConnect.Common.Tests.Utilities.DataAttributes.Ints.Base;
using InstaConnect.Common.Tests.Utilities.DataAttributes.Strings.Base;
using InstaConnect.PostCommentLikes.Application.Features.PostCommentLikes.Queries.GetAll;
using InstaConnect.PostCommentLikes.Domain.Features.PostCommentLikes.Models.Entities;
using InstaConnect.PostCommentLikes.Domain.Features.PostCommentLikes.Models.Requests;
using InstaConnect.PostComments.Common.Tests.Features.PostComments.Utilities;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities;
using InstaConnect.Posts.Common.Tests.Features.Users.Utilities;

namespace InstaConnect.PostCommentLikes.Common.Tests.Features.PostCommentLikes.Utilities.Builders.GetAllQueryRequest;

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
        _objectBuilder.With(p => p.Filter.Id, id, transformer);

        return this;
    }

    public GetAllPostCommentLikesQueryRequestBuilder WithCommentId(string commentId, IStringTransformer? transformer = null)
    {
        _objectBuilder.With(p => p.Filter.CommentId, commentId, transformer);

        return this;
    }

    public GetAllPostCommentLikesQueryRequestBuilder WithUserName(string userName, IStringTransformer? transformer = null)
    {
        _objectBuilder.With(p => p.Filter.UserName, userName, transformer);

        return this;
    }

    public GetAllPostCommentLikesQueryRequestBuilder WithPage(int page, IIntTransformer? transformer = null)
    {
        _objectBuilder.With(p => p.Pagination.Page, page, transformer);

        return this;
    }

    public GetAllPostCommentLikesQueryRequestBuilder WithPageSize(int pageSize, IIntTransformer? transformer = null)
    {
        _objectBuilder.With(p => p.Pagination.PageSize, pageSize, transformer);

        return this;
    }

    public GetAllPostCommentLikesQueryRequestBuilder WithSortOrder(SortOrder order, IEnumTransformer<SortOrder>? transformer = null)
    {
        _objectBuilder.With(p => p.Sorting.Order, order, transformer);

        return this;
    }

    public GetAllPostCommentLikesQueryRequestBuilder WithSortProperty(PostCommentLikeSortProperty property, IEnumTransformer<PostCommentLikeSortProperty>? transformer = null)
    {
        _objectBuilder.With(p => p.Sorting.Property, property, transformer);

        return this;
    }

    public GetAllPostCommentLikesQueryRequest Build()
    {
        return _objectBuilder.Build();
    }
}
