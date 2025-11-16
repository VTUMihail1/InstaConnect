using InstaConnect.Common.Application.Models;
using InstaConnect.Common.Presentation.Models.Payloads;

using Mapster;

namespace InstaConnect.Common.Presentation.Mappings;

internal class CommonPresentationMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<NamePayload, NameApiPayload>()
            .ConstructUsing(src => new(src.Value));

        config.NewConfig<NameApiPayload, NamePayload>()
            .ConstructUsing(src => new(src.Value));

        config.NewConfig<EmailPayload, EmailApiPayload>()
            .ConstructUsing(src => new(src.Value));

        config.NewConfig<EmailApiPayload, EmailPayload>()
            .ConstructUsing(src => new(src.Value));

        config.NewConfig<ImagePayload, ImageApiPayload>()
            .ConstructUsing(src => new(src.Url));

        config.NewConfig<ImageApiPayload, ImagePayload>()
            .ConstructUsing(src => new(src.Url));
    }
}
