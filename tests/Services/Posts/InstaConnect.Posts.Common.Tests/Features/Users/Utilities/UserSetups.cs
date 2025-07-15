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
using InstaConnect.Posts.Common.Tests.Features.Users.Utilities.Builders;
using InstaConnect.Posts.Domain.Features.Posts.Abstractions;
using InstaConnect.Posts.Domain.Features.Users.Abstractions;
using InstaConnect.Posts.Infrastructure;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Posts.Common.Tests.Features.Users.Utilities;
public static class UserSetups
{
    public static IUserRepository GetUserRepository(this IServiceScope serviceScope)
    {
        var userRepository = serviceScope.ServiceProvider.GetRequiredService<IUserRepository>();

        return userRepository;
    }

    public static async Task<User?> GetUserByIdAsync(
        this IServiceScope serviceScope,
        string id,
        CancellationToken cancellationToken)
    {
        var userRepository = serviceScope.ServiceProvider.GetRequiredService<IUserRepository>();
        var user = await userRepository.GetByIdAsync(id, cancellationToken);

        return user;
    }

    public static async Task<User> AddUserAsync(
        this IServiceScope serviceScope,
        CancellationToken cancellationToken)
    {
        var user = new UserBuilder().Create();
        var unitOfWork = serviceScope.ServiceProvider.GetRequiredService<IUnitOfWork>();
        var userRepository = serviceScope.ServiceProvider.GetRequiredService<IUserRepository>();

        userRepository.Add(user);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return user;
    }

    public static async Task ResetUserDatabase(
        this IServiceScope serviceScope,
        CancellationToken cancellationToken)
    {
        var dbContext = serviceScope.ServiceProvider.GetRequiredService<PostsContext>();

        if (await dbContext.Users.AnyAsync(cancellationToken))
        {
            await dbContext.Users.ExecuteDeleteAsync(cancellationToken);
        }
    }
}
