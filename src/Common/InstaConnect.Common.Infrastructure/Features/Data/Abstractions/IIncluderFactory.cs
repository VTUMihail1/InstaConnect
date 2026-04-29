using InstaConnect.Common.Domain.Features.Data.Abstractions;

namespace InstaConnect.Common.Infrastructure.Features.Data.Abstractions;

public interface IIncluderFactory<
    TIncludeType, TDestinationType, TIncludeDescriptor, TIncluder, TEntity>
    where TIncludeType : Enum
    where TDestinationType : Enum
    where TIncluder : IIncluder<TEntity, TIncludeType, TDestinationType>
    where TIncludeDescriptor : IIncludeDescriptor<TDestinationType, TIncludeType>
{
	public IEnumerable<TIncluder> Create(ICollection<TIncludeDescriptor>? descriptor);
}
