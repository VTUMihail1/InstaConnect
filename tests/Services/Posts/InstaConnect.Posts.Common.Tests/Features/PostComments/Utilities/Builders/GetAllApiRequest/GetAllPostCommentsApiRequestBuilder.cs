using InstaConnect.Common.Tests.Utilities;
using InstaConnect.Common.Tests.Utilities.Builders;
using InstaConnect.Common.Tests.Utilities.DataAttributes.Enums.Base;
using InstaConnect.Common.Tests.Utilities.DataAttributes.Ints.Base;
using InstaConnect.Common.Tests.Utilities.DataAttributes.Strings.Base;
using InstaConnect.PostComments.Domain.Features.PostComments.Models.Entities;
using InstaConnect.PostComments.Domain.Features.PostComments.Models.Requests;
using InstaConnect.PostComments.Presentation.Features.PostComments.Models.Requests;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities;
using InstaConnect.Posts.Common.Tests.Features.Users.Utilities;

namespace InstaConnect.PostComments.Common.Tests.Features.PostComments.Utilities.Builders.GetAllApiRequest;

public class GetAllPostCommentsApiRequestBuilder
{
    private readonly ObjectBuilder<GetAllPostCommentsApiRequest> _objectBuilder;

    public GetAllPostCommentsApiRequestBuilder(ObjectBuilder<GetAllPostCommentsApiRequest> objectBuilder)
    {
        _objectBuilder = objectBuilder;

        WithId(PostDataFaker.GetId());
        WithUserId(UserDataFaker.GetId());
        WithUserName(UserDataFaker.GetName());
        WithPage(PostCommentDataFaker.GetPage());
        WithPageSize(PostCommentDataFaker.GetPageSize());
        WithSortOrder(DataFaker.GetSortOrder());
        WithSortProperty(PostCommentDataFaker.GetSortProperty());
    }

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
        _objectBuilder.With(p => p.Filter.Id, id, transformer);

        return this;
    }

    public GetAllPostCommentsApiRequestBuilder WithUserId(string userId, IStringTransformer? transformer = null)
    {
        _objectBuilder.With(p => p.Filter.UserId, userId, transformer);

        return this;
    }

    public GetAllPostCommentsApiRequestBuilder WithUserName(string userName, IStringTransformer? transformer = null)
    {
        _objectBuilder.With(p => p.Filter.UserName, userName, transformer);

        return this;
    }

    public GetAllPostCommentsApiRequestBuilder WithPage(int page, IIntTransformer? transformer = null)
    {
        _objectBuilder.With(p => p.Pagination.Page, page, transformer);

        return this;
    }

    public GetAllPostCommentsApiRequestBuilder WithPageSize(int pageSize, IIntTransformer? transformer = null)
    {
        _objectBuilder.With(p => p.Pagination.PageSize, pageSize, transformer);

        return this;
    }

    public GetAllPostCommentsApiRequestBuilder WithSortOrder(SortOrder order, IEnumTransformer<SortOrder>? transformer = null)
    {
        _objectBuilder.With(p => p.Sorting.Order, order, transformer);

        return this;
    }

    public GetAllPostCommentsApiRequestBuilder WithSortProperty(PostCommentSortProperty property, IEnumTransformer<PostCommentSortProperty>? transformer = null)
    {
        _objectBuilder.With(p => p.Sorting.Property, property, transformer);

        return this;
    }

    public GetAllPostCommentsApiRequest Create()
    {
        return _objectBuilder.Create();
    }
}
