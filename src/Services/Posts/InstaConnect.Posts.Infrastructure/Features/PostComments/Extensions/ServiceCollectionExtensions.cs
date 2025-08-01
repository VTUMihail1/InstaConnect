using InstaConnect.Common.Extensions;
using InstaConnect.PostComments.Infrastructure.Features.PostComments.Abstractions;
using InstaConnect.Posts.Infrastructure.Extensions;

namespace InstaConnect.PostComments.Infrastructure.Features.PostComments.Extensions;

internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddPostCommentServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddImplementationsOf<IPostCommentSortProperty>(PostInfrastructureReference.Assembly);

        return serviceCollection;
    }
}
