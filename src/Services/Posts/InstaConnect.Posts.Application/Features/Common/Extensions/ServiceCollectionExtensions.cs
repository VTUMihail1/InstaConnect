using InstaConnect.Common.Application.Features.Common.Extensions;
using InstaConnect.Common.Application.Features.Messaging.Extensions;
using InstaConnect.Common.Domain.Features.Mappers.Extensions;

namespace InstaConnect.Posts.Application.Features.Common.Extensions;

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
