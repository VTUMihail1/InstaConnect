namespace InstaConnect.Common.Domain.Features.Data.Abstractions;

public interface IInclude<TDestinationType, TIncludeType, TIncludeDescriptor>
    where TDestinationType : Enum
    where TIncludeType : Enum
    where TIncludeDescriptor : IIncludeDescriptor<TDestinationType, TIncludeType>
{
    public ICollection<TIncludeDescriptor> Descriptors { get; }
}
