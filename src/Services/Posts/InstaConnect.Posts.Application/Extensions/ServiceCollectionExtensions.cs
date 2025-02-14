using InstaConnect.Posts.Application.Features.PostCommentLikes.Extensions;
using InstaConnect.Posts.Application.Features.PostComments.Extensions;
using InstaConnect.Posts.Application.Features.PostLikes.Extensions;
using InstaConnect.Posts.Application.Features.Posts.Extensions;
using InstaConnect.Shared.Application.Extensions;
using InstaConnect.Shared.Common.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Posts.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection serviceCollection)
    {
        serviceCollection
            .AddPostServices()
            .AddPostLikeServices()
            .AddPostCommentServices()
            .AddPostCommentLikeServices();

        serviceCollection
            .AddMediatR(ApplicationReference.Assembly)
            .AddMapper(ApplicationReference.Assembly)
            .AddValidators(ApplicationReference.Assembly);

        return serviceCollection;
    }
}
