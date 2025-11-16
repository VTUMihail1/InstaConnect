using InstaConnect.Common.Application.Models;
using InstaConnect.Common.Domain.Models.ValueObjects;

using Mapster;

namespace InstaConnect.Common.Application.Mappings;

internal class CommonApplicationMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Name, NamePayload>()
            .ConstructUsing(src => new(src.Value));

        config.NewConfig<NamePayload, Name>()
            .ConstructUsing(src => new(src.Value));

        config.NewConfig<Email, EmailPayload>()
            .ConstructUsing(src => new(src.Value));

        config.NewConfig<EmailPayload, Email>()
            .ConstructUsing(src => new(src.Value));

        config.NewConfig<Image, ImagePayload>()
            .ConstructUsing(src => new(src.Url));

        config.NewConfig<ImagePayload, Image>()
            .ConstructUsing(src => new(src.Url));
    }
}
