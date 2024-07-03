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
            .AddMemoryCache()
            .AddValidatorsFromAssembly(currentAssembly)
            .AddMediatR(currentAssembly)
            .AddAutoMapper(currentAssembly)
            .AddMessageBroker(configuration, busConfigurator =>
            {
                busConfigurator.AddConsumer<UserCreatedEventConsumer>();
                busConfigurator.AddConsumer<UserUpdatedEventConsumer>();
                busConfigurator.AddConsumer<UserDeletedEventConsumer>();
                busConfigurator.AddConsumer<PostLikeCreatedEventConsumer>();
                busConfigurator.AddConsumer<PostLikeDeletedEventConsumer>();
                busConfigurator.AddConsumer<PostCommentLikeCreatedEventConsumer>();
                busConfigurator.AddConsumer<PostCommentLikeDeletedEventConsumer>();
                busConfigurator.AddConsumer<PostCommentCreatedEventConsumer>();
                busConfigurator.AddConsumer<PostCommentUpdatedEventConsumer>();
                busConfigurator.AddConsumer<PostCommentDeletedEventConsumer>();
                busConfigurator.AddConsumer<PostCreatedEventConsumer>();
                busConfigurator.AddConsumer<PostUpdatedEventConsumer>();
                busConfigurator.AddConsumer<PostDeletedEventConsumer>();
            });

        return serviceCollection;
    }
}
