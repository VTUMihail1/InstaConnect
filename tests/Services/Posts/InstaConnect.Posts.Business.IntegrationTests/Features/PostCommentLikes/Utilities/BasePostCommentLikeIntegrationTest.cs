﻿using InstaConnect.Posts.Business.IntegrationTests.Utilities;
using InstaConnect.Posts.Common.Features.PostCommentLikes.Utilities;
using InstaConnect.Posts.Data;
using InstaConnect.Posts.Data.Features.PostCommentLikes.Abstract;
using InstaConnect.Posts.Data.Features.PostCommentLikes.Models.Entitites;
using InstaConnect.Posts.Data.Features.PostComments.Abstract;
using InstaConnect.Posts.Data.Features.PostComments.Models.Entitites;
using InstaConnect.Posts.Data.Features.Posts.Abstract;
using InstaConnect.Posts.Data.Features.Posts.Models.Entitites;
using InstaConnect.Posts.Data.Features.Users.Abstract;
using InstaConnect.Posts.Data.Features.Users.Models.Entitites;
using InstaConnect.Shared.Business.IntegrationTests.Utilities;
using InstaConnect.Shared.Data.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Posts.Business.IntegrationTests.Features.PostCommentLikes.Utilities;

public abstract class BasePostCommentLikeIntegrationTest : BaseSharedIntegrationTest, IClassFixture<IntegrationTestWebAppFactory>, IAsyncLifetime
{
    protected IUserWriteRepository UserWriteRepository
    {
        get
        {
            var serviceScope = ServiceScope.ServiceProvider.CreateScope();
            var userWriteRepository = serviceScope.ServiceProvider.GetRequiredService<IUserWriteRepository>();

            return userWriteRepository;
        }
    }

    protected IPostCommentLikeWriteRepository PostCommentLikeWriteRepository
    {
        get
        {
            var serviceScope = ServiceScope.ServiceProvider.CreateScope();
            var PostCommentLikeWriteRepository = serviceScope.ServiceProvider.GetRequiredService<IPostCommentLikeWriteRepository>();

            return PostCommentLikeWriteRepository;
        }
    }

    protected IPostCommentLikeReadRepository PostCommentLikeReadRepository
    {
        get
        {
            var serviceScope = ServiceScope.ServiceProvider.CreateScope();
            var PostCommentLikeReadRepository = serviceScope.ServiceProvider.GetRequiredService<IPostCommentLikeReadRepository>();

            return PostCommentLikeReadRepository;
        }
    }

    protected BasePostCommentLikeIntegrationTest(IntegrationTestWebAppFactory integrationTestWebAppFactory)
        : base(integrationTestWebAppFactory.Services.CreateScope())
    {
    }

    protected async Task<string> CreatePostAsync(string userId, CancellationToken cancellationToken)
    {
        var post = new Post(
            PostCommentLikeTestUtilities.ValidPostTitle,
            PostCommentLikeTestUtilities.ValidPostContent,
            userId);

        var unitOfWork = ServiceScope.ServiceProvider.GetRequiredService<IUnitOfWork>();
        var postWriteRepository = ServiceScope.ServiceProvider.GetRequiredService<IPostWriteRepository>();

        postWriteRepository.Add(post);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return post.Id;
    }

    protected async Task<string> CreatePostCommentAsync(string userId, string postId, CancellationToken cancellationToken)
    {
        var postComment = new PostComment(
            userId,
            postId,
            PostCommentLikeTestUtilities.ValidPostCommentContent);

        var unitOfWork = ServiceScope.ServiceProvider.GetRequiredService<IUnitOfWork>();
        var postCommentWriteRepository = ServiceScope.ServiceProvider.GetRequiredService<IPostCommentWriteRepository>();

        postCommentWriteRepository.Add(postComment);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return postComment.Id;
    }

    protected async Task<string> CreatePostCommentLikeAsync(string userId, string postCommentId, CancellationToken cancellationToken)
    {
        var PostCommentLike = new PostCommentLike(
            postCommentId,
            userId);

        var unitOfWork = ServiceScope.ServiceProvider.GetRequiredService<IUnitOfWork>();
        var PostCommentLikeWriteRepository = ServiceScope.ServiceProvider.GetRequiredService<IPostCommentLikeWriteRepository>();

        PostCommentLikeWriteRepository.Add(PostCommentLike);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return PostCommentLike.Id;
    }

    protected async Task<string> CreateUserAsync(CancellationToken cancellationToken)
    {
        var user = new User(
            PostCommentLikeTestUtilities.ValidUserFirstName,
            PostCommentLikeTestUtilities.ValidUserLastName,
            PostCommentLikeTestUtilities.ValidUserEmail,
            PostCommentLikeTestUtilities.ValidUserName,
            PostCommentLikeTestUtilities.ValidUserProfileImage);

        var unitOfWork = ServiceScope.ServiceProvider.GetRequiredService<IUnitOfWork>();
        var userWriteRepository = ServiceScope.ServiceProvider.GetRequiredService<IUserWriteRepository>();

        userWriteRepository.Add(user);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return user.Id;
    }

    public async Task InitializeAsync()
    {
        await EnsureDatabaseIsEmpty();
    }

    public async Task DisposeAsync()
    {
        await EnsureDatabaseIsEmpty();
    }

    private async Task EnsureDatabaseIsEmpty()
    {
        var dbContext = ServiceScope.ServiceProvider.GetRequiredService<PostsContext>();

        if (dbContext.PostCommentLikes.Any())
        {
            await dbContext.PostCommentLikes.ExecuteDeleteAsync(CancellationToken);
        }

        if (dbContext.PostComments.Any())
        {
            await dbContext.PostComments.ExecuteDeleteAsync(CancellationToken);
        }

        if (dbContext.Posts.Any())
        {
            await dbContext.Posts.ExecuteDeleteAsync(CancellationToken);
        }

        if (dbContext.Users.Any())
        {
            await dbContext.Users.ExecuteDeleteAsync(CancellationToken);
        }
    }
}
