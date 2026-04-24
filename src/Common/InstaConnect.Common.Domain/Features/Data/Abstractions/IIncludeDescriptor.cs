namespace InstaConnect.Common.Domain.Features.Data.Abstractions;

public interface IIncludeDescriptor<out TDestinationType, out TIncludeType>
    where TDestinationType : Enum
    where TIncludeType : Enum
{
    TDestinationType DestinationType { get; }
    TIncludeType IncludeType { get; }
}
