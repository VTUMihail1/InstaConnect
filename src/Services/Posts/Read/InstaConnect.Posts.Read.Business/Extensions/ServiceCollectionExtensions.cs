using FluentValidation;
using InstaConnect.Posts.Read.Business.Consumers.PostCommentLikes;
using InstaConnect.Posts.Read.Business.Consumers.PostComments;
using InstaConnect.Posts.Read.Business.Consumers.PostLikes;
using InstaConnect.Posts.Read.Business.Consumers.Posts;
using InstaConnect.Posts.Read.Business.Consumers.Users;
using InstaConnect.Shared.Business.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Posts.Read.Business.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddBusinessLayer(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        var currentAssembly = typeof(ServiceCollectionExtensions).Assembly;

        serviceCollection
            .AddCachingHandler()
            .AddValidatorsFromAssembly(currentAssembly)
            .AddMediatR(currentAssembly)
            .AddAutoMapper(currentAssembly)
            .AddMessageBroker(configuration, currentAssembly);

        return serviceCollection;
    }
}
