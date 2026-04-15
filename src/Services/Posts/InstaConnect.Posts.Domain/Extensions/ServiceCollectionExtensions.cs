using InstaConnect.Common.Domain.Extensions;
using InstaConnect.Posts.Domain.Features.PostCommentLikes.Extensions;
using InstaConnect.Posts.Domain.Features.PostComments.Extensions;
using InstaConnect.Posts.Domain.Features.PostLikes.Extensions;
using InstaConnect.Posts.Domain.Features.Posts.Extensions;
using InstaConnect.Posts.Domain.Features.Users.Extensions;

namespace InstaConnect.Posts.Domain.Extensions;

public static class ServiceCollectionExtensions
{
    extension(IServiceCollection serviceCollection)
    {
        public IServiceCollection AddDomain()
        {
            serviceCollection
                .AddUserServices()
                .AddPostServices()
                .AddPostLikeServices()
                .AddPostCommentServices()
                .AddPostCommentLikeServices();

            serviceCollection
                .AddMapper(PostDomainReference.Assembly, CommonDomainReference.Assembly)
                .AddServicesWithMatchingInterfaces(PostDomainReference.Assembly);

            return serviceCollection;
        }
    }
}
