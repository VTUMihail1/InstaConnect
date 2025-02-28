using InstaConnect.Common.Application.Extensions;
using InstaConnect.Common.Extensions;
using InstaConnect.Posts.Application.Features.PostCommentLikes.Extensions;
using InstaConnect.Posts.Application.Features.PostComments.Extensions;
using InstaConnect.Posts.Application.Features.PostLikes.Extensions;
using InstaConnect.Posts.Application.Features.Posts.Extensions;

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
