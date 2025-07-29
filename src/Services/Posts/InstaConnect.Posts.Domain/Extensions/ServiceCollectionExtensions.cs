using InstaConnect.Common.Extensions;
using InstaConnect.PostCommentLikes.Domain.Features.PostCommentLikes.Extensions;
using InstaConnect.PostComments.Domain.Features.PostComments.Extensions;
using InstaConnect.PostLikes.Domain.Features.PostLikes.Extensions;
using InstaConnect.Posts.Domain.Extensions;
using InstaConnect.Posts.Domain.Features.Posts.Extensions;
using InstaConnect.Posts.Domain.Features.Users.Extensions;

using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Posts.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDomain(this IServiceCollection serviceCollection)
    {
        serviceCollection
            .AddUserServices()
            .AddPostServices()
            .AddPostLikeServices()
            .AddPostCommentServices()
            .AddPostCommentLikeServices();

        serviceCollection
            .AddMapper(PostDomainReference.Assembly)
            .AddServicesWithMatchingInterfaces(PostDomainReference.Assembly);

        return serviceCollection;
    }
}
