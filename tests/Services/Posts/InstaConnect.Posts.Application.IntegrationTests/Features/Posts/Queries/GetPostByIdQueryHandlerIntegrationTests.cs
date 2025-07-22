using System.Data.Common;

using InstaConnect.Common.Exceptions;
using InstaConnect.Common.Tests.Utilities.DataAttributes.String;
using InstaConnect.Common.Tests.Utilities.DataAttributes.String.Value;
using InstaConnect.Common.Tests.Utilities.Variants.String;
using InstaConnect.Posts.Application.Features.Posts.Queries.GetById;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Assertions;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Builders;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.DataAttributes.Id;
using InstaConnect.Posts.Common.Tests.Features.Utilities;
using InstaConnect.Posts.Domain.Features.Users.Models.Entities;

namespace InstaConnect.Posts.Application.IntegrationTests.Features.Posts.Queries;

public class GetPostByIdQueryHandlerIntegrationTests : BasePostIntegrationTest
{
    private User _user;
    private Post _post;
    private GetPostByIdQueryRequestBuilder _queryBuilder;

    public GetPostByIdQueryHandlerIntegrationTests(PostsWebApplicationFactory postsWebApplicationFactory) : base(postsWebApplicationFactory)
    {
    }

    protected override async Task OnInitializeAsync()
    {
        _user = await ServiceScope.AddUserAsync(CancellationToken);
        _post = await ServiceScope.AddPostAsync(_user, CancellationToken);
        _queryBuilder = new(_post);
    }

    [Theory]
    [PostIdNullWithMessageData]
    [PostIdEmptyWithMessageData]
    [PostIdTooShortWithMessageData]
    [PostIdTooLongWithMessageData]
    public async Task SendAsync_ShouldThrowValidationException_WhenIdIsInvalid(string id, string errorMessage)
    {
        // Arrange
        var request = _queryBuilder.WithId(id).Create();

        // Act
        var action = async () => await ApplicationSender.SendAsync(request, CancellationToken);

        // Assert
        await action.ShouldThrowInvalidValidationExceptionAsync(errorMessage);
    }

    [Fact]
    public async Task SendAsync_ShouldThrowPostNotFoundException_WhenIdIsInvalid()
    {
        // Arrange
        var request = _queryBuilder.WithInvalidId().Create();

        // Act
        var action = async () => await ApplicationSender.SendAsync(request, CancellationToken);

        // Assert
        await action.ShouldThrowPostNotFoundExceptionAsync(_post.Id);
    }

    [Fact]
    public async Task SendAsync_ShouldReturnResponse_WhenRequestIsValid()
    {
        // Arrange
        var request = _queryBuilder.Create();

        // Act
        var response = await ApplicationSender.SendAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfy(_post, _user);
    }

    [Theory]
    [DifferentCaseStringVariantTypeData]
    public async Task SendAsync_ShouldReturnResponse_WhenRequestIsValidAndIdHasDifferentVariants(StringVariantType type)
    {
        // Arrange
        var request = _queryBuilder.WithId(_post.Id, type).Create();

        // Act
        var response = await ApplicationSender.SendAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfy(_post, _user);
    }
}
