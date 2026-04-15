using InstaConnect.Common.Domain.Abstractions;

using MapsterMapper;

namespace InstaConnect.Common.Domain.Helpers;

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
