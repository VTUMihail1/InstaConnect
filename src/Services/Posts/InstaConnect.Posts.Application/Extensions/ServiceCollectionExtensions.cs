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
                .AddCQRS(PostsApplicationReference.Assembly)
                .AddMapper(PostsApplicationReference.Assembly, CommonApplicationReference.Assembly)
                .AddValidators(PostsApplicationReference.Assembly);

            return serviceCollection;
        }
    }
}
