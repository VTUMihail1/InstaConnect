using InstaConnect.Common.Domain.Features.Databases.Abstractions;

namespace InstaConnect.Common.Domain.Features.Databases.Models;

public abstract record Include<TDestinationType, TIncludeType, TIncludeDescriptor>(ICollection<TIncludeDescriptor> Descriptors)
	: IInclude<TDestinationType, TIncludeType, TIncludeDescriptor>
	where TDestinationType : Enum
	where TIncludeType : Enum
	where TIncludeDescriptor : IIncludeDescriptor<TDestinationType, TIncludeType>
{
	public virtual bool Equals(Include<TDestinationType, TIncludeType, TIncludeDescriptor>? other)
	{
		return other is not null &&
			   EqualityContract == other.EqualityContract &&
			   Descriptors.SequenceEqual(other.Descriptors);
	}

	public override int GetHashCode()
	{
		return Descriptors.Aggregate(EqualityContract.GetHashCode(), (hash, descriptor) => HashCode.Combine(hash, descriptor));
	}
}
