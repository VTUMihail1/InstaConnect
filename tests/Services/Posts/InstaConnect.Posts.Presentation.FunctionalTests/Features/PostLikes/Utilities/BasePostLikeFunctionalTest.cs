﻿using InstaConnect.Common.Application.Abstractions;
using InstaConnect.Posts.Domain.Features.PostLikes.Abstractions;
using InstaConnect.Posts.Domain.Features.Posts.Abstractions;
using InstaConnect.Posts.Domain.Features.Users.Abstractions;
using InstaConnect.Posts.Infrastructure;
using InstaConnect.Posts.Presentation.FunctionalTests.Features.PostLikes.Abstractions;
using InstaConnect.Posts.Presentation.FunctionalTests.Features.PostLikes.Helpers;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Posts.Presentation.FunctionalTests.Features.PostLikes.Utilities;

public abstract class BasePostLikeFunctionalTest : IClassFixture<PostsWebApplicationFactory>, IAsyncLifetime
{
    protected CancellationToken CancellationToken { get; }

    protected IServiceScope ServiceScope { get; }

    protected IPostLikesClient PostLikesClient { get; }

    protected IPostLikeWriteRepository PostLikeWriteRepository
    {
        get
        {
            var serviceScope = ServiceScope.ServiceProvider.CreateScope();
            var postLikeRepository = serviceScope.ServiceProvider.GetRequiredService<IPostLikeWriteRepository>();

            return postLikeRepository;
        }
    }

    protected IPostLikeReadRepository PostLikeReadRepository
    {
        get
        {
            var serviceScope = ServiceScope.ServiceProvider.CreateScope();
            var postLikeReadRepository = serviceScope.ServiceProvider.GetRequiredService<IPostLikeReadRepository>();

            return postLikeReadRepository;
        }
    }

    protected BasePostLikeFunctionalTest(PostsWebApplicationFactory postsWebApplicationFactory)
    {
        ServiceScope = postsWebApplicationFactory.Services.CreateScope();
        CancellationToken = new();
        PostLikesClient = new PostLikesClient(postsWebApplicationFactory.CreateClient());
    }

    private async Task<User> CreateUserUtilAsync(CancellationToken cancellationToken)
    {
        var user = new User(
            SharedTestUtilities.GetAverageString(UserConfigurations.FirstNameMaxLength, UserConfigurations.FirstNameMinLength),
            SharedTestUtilities.GetAverageString(UserConfigurations.LastNameMaxLength, UserConfigurations.LastNameMinLength),
            SharedTestUtilities.GetAverageString(UserConfigurations.EmailMaxLength, UserConfigurations.EmailMinLength),
            SharedTestUtilities.GetAverageString(UserConfigurations.NameMaxLength, UserConfigurations.NameMinLength),
            SharedTestUtilities.GetAverageString(UserConfigurations.ProfileImageMaxLength, UserConfigurations.ProfileImageMinLength));

        var unitOfWork = ServiceScope.ServiceProvider.GetRequiredService<IUnitOfWork>();
        var userWriteRepository = ServiceScope.ServiceProvider.GetRequiredService<IUserWriteRepository>();

        userWriteRepository.Add(user);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return user;
    }

    protected async Task<User> CreateUserAsync(CancellationToken cancellationToken)
    {
        var user = await CreateUserUtilAsync(cancellationToken);

        return user;
    }

    private async Task<Post> CreatePostAsyncUtil(User user, CancellationToken cancellationToken)
    {
        var post = new Post(
            SharedTestUtilities.GetAverageString(PostConfigurations.TitleMaxLength, PostConfigurations.TitleMinLength),
            SharedTestUtilities.GetAverageString(PostConfigurations.ContentMaxLength, PostConfigurations.ContentMinLength),
            user);

        var unitOfWork = ServiceScope.ServiceProvider.GetRequiredService<IUnitOfWork>();
        var postWriteRepository = ServiceScope.ServiceProvider.GetRequiredService<IPostWriteRepository>();

        postWriteRepository.Add(post);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return post;
    }

    protected async Task<Post> CreatePostAsync(CancellationToken cancellationToken)
    {
        var user = await CreateUserAsync(CancellationToken);
        var post = await CreatePostAsyncUtil(user, cancellationToken);

        return post;
    }

    private async Task<PostLike> CreatePostLikeUtilAsync(User user, Post post, CancellationToken cancellationToken)
    {
        var postLike = new PostLike(
            post,
            user);

        var unitOfWork = ServiceScope.ServiceProvider.GetRequiredService<IUnitOfWork>();
        var postLikeWriteRepository = ServiceScope.ServiceProvider.GetRequiredService<IPostLikeWriteRepository>();

        postLikeWriteRepository.Add(postLike);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return postLike;
    }

    protected async Task<PostLike> CreatePostLikeAsync(CancellationToken cancellationToken)
    {
        var user = await CreateUserAsync(cancellationToken);
        var post = await CreatePostAsync(cancellationToken);
        var postLike = await CreatePostLikeUtilAsync(user, post, cancellationToken);

        return postLike;
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

        if (await dbContext.PostLikes.AnyAsync(CancellationToken))
        {
            await dbContext.PostLikes.ExecuteDeleteAsync(CancellationToken);
        }

        if (await dbContext.Posts.AnyAsync(CancellationToken))
        {
            await dbContext.Posts.ExecuteDeleteAsync(CancellationToken);
        }

        if (await dbContext.Users.AnyAsync(CancellationToken))
        {
            await dbContext.Users.ExecuteDeleteAsync(CancellationToken);
        }
    }
}
