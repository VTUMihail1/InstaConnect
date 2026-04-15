namespace InstaConnect.Common.Domain.Abstractions;

public interface IInclude<TDestinationType, TIncludeType, TIncludeDescriptor>
    where TDestinationType : Enum
    where TIncludeType : Enum
    where TIncludeDescriptor : IIncludeDescriptor<TDestinationType, TIncludeType>
{
    ICollection<TIncludeDescriptor> Descriptors { get; }
}
