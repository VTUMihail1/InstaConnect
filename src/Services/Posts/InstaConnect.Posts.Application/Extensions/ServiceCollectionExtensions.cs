using InstaConnect.Common.Domain.Extensions;

namespace InstaConnect.Posts.Application.Extensions;

public static class ServiceCollectionExtensions
{
    extension(IServiceCollection serviceCollection)
    {
        public IServiceCollection AddApplication()
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
}
