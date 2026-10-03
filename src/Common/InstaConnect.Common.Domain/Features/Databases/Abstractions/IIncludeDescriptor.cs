namespace InstaConnect.Common.Domain.Features.Databases.Abstractions;

public interface IIncludeDescriptor<out TDestinationType, out TIncludeType>
	where TDestinationType : Enum
	where TIncludeType : Enum
{
	public TDestinationType DestinationType { get; }

	public TIncludeType IncludeType { get; }
}
