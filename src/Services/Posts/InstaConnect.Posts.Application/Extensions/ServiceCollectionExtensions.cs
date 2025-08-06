using InstaConnect.Common.Application.Extensions;
using InstaConnect.Common.Extensions;
using InstaConnect.PostCommentLikes.Application.Features.PostCommentLikes.Extensions;
using InstaConnect.PostComments.Application.Features.PostComments.Extensions;
using InstaConnect.PostLikes.Application.Features.PostLikes.Extensions;
using InstaConnect.Posts.Application.Features.Posts.Extensions;

namespace InstaConnect.Posts.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection serviceCollection)
    {
        serviceCollection
            .AddUserServices()
            .AddPostServices()
            .AddPostLikeServices()
            .AddPostCommentServices()
            .AddPostCommentLikeServices();

        serviceCollection
            .AddCQRS(PostApplicationReference.Assembly)
            .AddMapper(PostApplicationReference.Assembly)
            .AddValidators(PostApplicationReference.Assembly);

        return serviceCollection;
    }
}
