using InstaConnect.Common.Domain.Models.ValueObjects;
using InstaConnect.Common.Events.Models;

using Mapster;

namespace InstaConnect.Common.Domain.Mappings;

internal class CommonDomainMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Name, NameEventPayload>()
            .ConstructUsing(src => new(src.Value));

        config.NewConfig<Email, EmailEventPayload>()
            .ConstructUsing(src => new(src.Value));

        config.NewConfig<Image, ImageEventPayload>()
            .ConstructUsing(src => new(src.Url));
    }
}
