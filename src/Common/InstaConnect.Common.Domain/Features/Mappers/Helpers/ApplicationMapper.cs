using InstaConnect.Common.Domain.Features.Mappers.Abstractions;

using MapsterMapper;

namespace InstaConnect.Common.Domain.Features.Mappers.Helpers;

public class ApplicationMapper : IApplicationMapper
{
    private readonly IMapper _mapper;

    public ApplicationMapper(IMapper mapper)
    {
        _mapper = mapper;
    }

    public T Map<T>(object source)
    {
        var obj = _mapper.Map<T>(source);

        return obj;
    }
}
