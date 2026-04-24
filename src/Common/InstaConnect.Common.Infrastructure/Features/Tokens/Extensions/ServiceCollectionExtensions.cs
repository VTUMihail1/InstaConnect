using InstaConnect.Common.Infrastructure.Extensions;
using InstaConnect.Common.Infrastructure.Features.Tokens.Abstractions;
using InstaConnect.Common.Infrastructure.Features.Tokens.Helpers;
using InstaConnect.Common.Infrastructure.Features.Tokens.Models;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace InstaConnect.Common.Infrastructure.Extensions;

public static partial class ServiceCollectionExtensions
{
    extension(IServiceCollection serviceCollection)
    {
        public IServiceCollection AddJwtBearer(IConfiguration configuration)
        {
            serviceCollection.AddValidatedOptions<AccessTokenOptions>(AccessTokenOptions.SectionName);
            var options = configuration.GetOptions<AccessTokenOptions>(AccessTokenOptions.SectionName);

            serviceCollection.AddScoped<IEncoder, Encoder>();

            serviceCollection.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(opt =>
            {
                var encoder = serviceCollection.BuildServiceProvider()
                                              .GetRequiredService<IEncoder>();

                opt.RequireHttpsMetadata = false;
                opt.SaveToken = true;
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    IssuerSigningKey = new SymmetricSecurityKey(encoder.GetBytesUTF8(options.SecurityKey)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            return serviceCollection;
        }
    }
}
