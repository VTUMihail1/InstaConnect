using InstaConnect.Common.Domain.Extensions;

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
            .AddMapper(PostApplicationReference.Assembly, CommonApplicationReference.Assembly)
            .AddValidators(PostApplicationReference.Assembly);

        return serviceCollection;
    }
}
