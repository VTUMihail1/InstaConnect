using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Models.Requests;
using InstaConnect.Posts.Application.Features.Posts.Commands.Add;
using InstaConnect.EmailConfirmationTokens.Application.Features.EmailConfirmationTokens.Commands.Add;
using InstaConnect.EmailConfirmationTokens.Application.Features.EmailConfirmationTokens.Commands.Delete;
using InstaConnect.EmailConfirmationTokens.Domain.Features.EmailConfirmationTokens.Models.Responses;

using Mapster;

namespace InstaConnect.EmailConfirmationTokens.Application.Features.EmailConfirmationTokens.Mappings;

public class EmailConfirmationTokenApplicationMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {

        config.NewConfig<AddEmailConfirmationTokenCommandRequest, AddEmailConfirmationTokenCommand>()
            .ConstructUsing(src => new(src.Name));

        config.NewConfig<VerifyEmailConfirmationTokenCommandRequest, VerifyEmailConfirmationTokenCommand>()
            .ConstructUsing(src => new(src.Id, src.Value));
    }
}
