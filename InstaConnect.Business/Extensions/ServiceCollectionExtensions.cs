using InstaConnect.Business.Abstraction.Factories;
using InstaConnect.Business.Abstraction.Helpers;
using InstaConnect.Business.Abstraction.Services;
using InstaConnect.Business.AutoMapper;
using InstaConnect.Business.Factories;
using InstaConnect.Business.Helpers;
using InstaConnect.Business.Models.Options;
using InstaConnect.Business.Services;
using InstaConnect.Data.Abstraction.Repositories;
using InstaConnect.Data.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SendGrid;

namespace InstaConnect.Business.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddBusinessLayer(this IServiceCollection services, IConfiguration configuration) 
        {
            var emailOptions = configuration.GetSection(nameof(EmailOptions)).Get<EmailOptions>();

            services
                .AddScoped<ISendGridClient>(_ => new SendGridClient(emailOptions!.APIKey))
                .AddScoped<IEndpointHandler, EndpointHandler>()
                .AddScoped<IEmailFactory, EmailFactory>()
                .AddScoped<IEmailSender, EmailSender>()
                .AddScoped<IEndpointHandler, EndpointHandler>()
                .AddScoped<IEmailService, EmailService>()
                .AddScoped<ITemplateGenerator, TemplateGenerator>()
                .AddScoped<ITokenService, TokenService>()
                .AddScoped<IPostRepository, PostRepository>()
                .AddScoped<IPostService, PostService>()
                .AddScoped<IMessageService, MessageService>()
                .AddScoped<IPostCommentService, PostCommentService>()
                .AddScoped<IPostLikeService, PostLikeService>()
                .AddScoped<IPostCommentLikeService, PostCommentLikeService>()
                .AddScoped<IFollowService, FollowService>()
                .AddScoped<ITokenGenerator, TokenGenerator>()
                .AddScoped<IMessageSender, MessageSender>()
                .AddScoped<IResultFactory, ResultFactory>()
                .AddScoped<IUserService, UserService>()
                .AddScoped<IAccountService, AccountService>()
                .AddAutoMapper(typeof(InstaConnectProfile));

            return services;
        }
    }
}
