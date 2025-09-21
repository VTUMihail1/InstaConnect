using InstaConnect.ForgotPasswordTokens.Application.Features.ForgotPasswordTokens.Commands.Add;
using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Models.Requests;

using Mapster;

namespace InstaConnect.ForgotPasswordTokens.Application.Features.ForgotPasswordTokens.Mappings;

public class ForgotPasswordTokenApplicationMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {

        config.NewConfig<AddForgotPasswordTokenCommandRequest, AddForgotPasswordTokenCommand>()
            .ConstructUsing(src => new(src.Name));

        config.NewConfig<VerifyForgotPasswordTokenCommandRequest, VerifyForgotPasswordTokenCommand>()
            .ConstructUsing(src => new(src.Id, src.Value, src.Password, src.ConfirmPassword));
    }
}
