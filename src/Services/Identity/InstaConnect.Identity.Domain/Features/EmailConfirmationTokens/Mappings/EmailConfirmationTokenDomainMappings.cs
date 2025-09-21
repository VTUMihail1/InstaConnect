using InstaConnect.Common.Application.Contracts.Users;
using InstaConnect.Common.Domain.Events.EmailConfirmationTokens;
using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Models.Entities;
using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Models.Requests;
using InstaConnect.Posts.Domain.Features.Users.Models.Entities;

using Mapster;

namespace InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Mappings;

internal class EmailConfirmationTokenDomainMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<EmailConfirmationToken, EmailConfirmationTokenAddedEventRequest>()
            .ConstructUsing(ect => new(
                ect.Id,
                ect.Value,
                ect.ExpiresAt));

        config.NewConfig<User, GetAllEmailConfirmationTokensQuery>()
            .ConstructUsing(ect => new(
                new(ect.Id)));
    }
}
