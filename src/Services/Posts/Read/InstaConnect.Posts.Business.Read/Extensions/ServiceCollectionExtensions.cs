using FluentValidation;
using InstaConnect.Posts.Business.Read.Consumers;
using InstaConnect.Posts.Business.Read.Consumers.PostCommentLikes;
using InstaConnect.Posts.Business.Read.Consumers.PostComments;
using InstaConnect.Posts.Business.Read.Consumers.PostLikes;
using InstaConnect.Posts.Business.Read.Consumers.Posts;
using InstaConnect.Posts.Business.Read.Consumers.Users;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Contracts;
using InstaConnect.Shared.Business.Extensions;
using InstaConnect.Shared.Business.Helpers;
using InstaConnect.Shared.Business.Models.Options;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Posts.Business.Read.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddBusinessLayer(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        var currentAssembly = typeof(ServiceCollectionExtensions).Assembly;

        serviceCollection
            .AddValidatorsFromAssembly(currentAssembly)
            .AddMediatR(currentAssembly)
            .AddAutoMapper(currentAssembly)
            .AddCurrentUserContext()
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
