﻿using AutoMapper;
using InstaConnect.Shared.Application.Abstractions;

namespace InstaConnect.Shared.Application.Helpers;

public class InstaConnectMapper : IInstaConnectMapper
{
    private readonly IMapper _mapper;

    public InstaConnectMapper(IMapper mapper)
    {
        _mapper = mapper;
    }

    public T Map<T>(object source)
    {
        var obj = _mapper.Map<T>(source);

        return obj;
    }

    public void Map(object source, object destination)
    {
        _mapper.Map(source, destination);
    }
}
