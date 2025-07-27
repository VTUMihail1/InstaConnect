using InstaConnect.Common.Extensions;
using InstaConnect.PostLikes.Domain.Features.PostLikes.Extensions;
using InstaConnect.Posts.Domain.Extensions;
using InstaConnect.Posts.Domain.Features.Posts.Extensions;
using InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Extensions;
using InstaConnect.Posts.Infrastructure.Features.PostComments.Extensions;
using InstaConnect.Posts.Infrastructure.Features.PostLikes.Extensions;
using InstaConnect.Posts.Infrastructure.Features.Posts.Extensions;
using InstaConnect.Posts.Infrastructure.Features.Users.Extensions;
using InstaConnect.Shared.Infrastructure.Extensions;

using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Posts.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDomain(this IServiceCollection serviceCollection)
    {
        serviceCollection
            .AddPostServices()
            .AddPostLikeServices();

        serviceCollection
            .AddMapper(PostDomainReference.Assembly)
            .AddServicesWithMatchingInterfaces(PostDomainReference.Assembly);

        return serviceCollection;
    }
}
