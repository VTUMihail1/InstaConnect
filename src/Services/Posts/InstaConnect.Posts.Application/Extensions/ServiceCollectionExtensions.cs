using InstaConnect.Common.Application.Extensions;
using InstaConnect.Common.Domain.Extensions;
using InstaConnect.Posts.Application.Features.PostCommentLikes.Extensions;
using InstaConnect.Posts.Application.Features.PostComments.Extensions;
using InstaConnect.Posts.Application.Features.PostLikes.Extensions;
using InstaConnect.Posts.Application.Features.Posts.Extensions;
using InstaConnect.Posts.Application.Features.Users.Extensions;

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
