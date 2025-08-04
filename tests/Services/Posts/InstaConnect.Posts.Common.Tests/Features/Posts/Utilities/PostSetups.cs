using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using InstaConnect.Common.Application.Abstractions;
using InstaConnect.Common.Tests.Utilities;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Builders;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Factories;
using InstaConnect.Posts.Domain.Features.Posts.Abstractions;
using InstaConnect.Posts.Domain.Features.Users.Abstractions;
using InstaConnect.Posts.Infrastructure;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Posts.Common.Tests.Features.Posts.Utilities;
public static class PostSetups
{
    public static IPostRepository GetPostRepository(this IServiceScope serviceScope)
    {
        var postRepository = serviceScope.ServiceProvider.GetRequiredService<IPostRepository>();

        return postRepository;
    }

    public static async Task<Post?> GetPostByIdAsync(
        this IServiceScope serviceScope,
        string id,
        CancellationToken cancellationToken)
    {
        var postRepository = serviceScope.GetPostRepository();
        var post = await postRepository.GetByIdAsync(id, cancellationToken);

        return post;
    }

    public static async Task<Post> AddPostAsync(
        this IServiceScope serviceScope,
        Post post,
        CancellationToken cancellationToken)
    {
        var unitOfWork = serviceScope.GetUnitOfWork();
        var postRepository = serviceScope.GetPostRepository();

        postRepository.Add(post);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return post;
    }

    public static async Task ResetPostDatabase(
        this IServiceScope serviceScope,
        CancellationToken cancellationToken)
    {
        var dbContext = serviceScope.ServiceProvider.GetRequiredService<PostsContext>();

        if (await dbContext.Posts.AnyAsync(cancellationToken))
        {
            await dbContext.Posts.ExecuteDeleteAsync(cancellationToken);
        }

        if (await dbContext.Users.AnyAsync(cancellationToken))
        {
            await dbContext.Users.ExecuteDeleteAsync(cancellationToken);
        }
    }
}
