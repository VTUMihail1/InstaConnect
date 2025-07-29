using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.PostComments.Domain.Features.PostComments.Extensions;

internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddPostCommentServices(this IServiceCollection serviceCollection)
    {
        return serviceCollection;
    }
}
