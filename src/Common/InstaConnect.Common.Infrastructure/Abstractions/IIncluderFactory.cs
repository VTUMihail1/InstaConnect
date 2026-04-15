using InstaConnect.Common.Domain.Abstractions;

namespace InstaConnect.Common.Infrastructure.Abstractions;

public interface IIncluderFactory<
    TIncludeType, TDestinationType, TIncludeDescriptor, TIncluder, TEntity>
    where TIncludeType : Enum
    where TDestinationType : Enum
    where TIncluder : IIncluder<TEntity, TIncludeType, TDestinationType>
    where TIncludeDescriptor : IIncludeDescriptor<TDestinationType, TIncludeType>
{
    IEnumerable<TIncluder> Create(ICollection<TIncludeDescriptor>? descriptor);
}
