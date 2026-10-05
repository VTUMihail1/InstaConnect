using InstaConnect.Common.Domain.Features.ValueObjects.Models;
using InstaConnect.Common.Tests.Features.DataAttributes.Base;
using InstaConnect.Common.Tests.Features.DataAttributes.Strings.Base;

namespace InstaConnect.Common.Infrastructure.Tests.Features.Builders;

public class NameBuilder
{
	private string _name;

	public NameBuilder(Name name)
	{
		_name = name.Value;
	}

	public NameBuilder WithName(Name name, IStringTransformer? transformer = null)
	{
		_name = transformer.TryTransform(name.Value);

		return this;
	}

	public NameBuilder WithName(IStringTransformer transformer)
	{
		_name = transformer.Transform(_name);

		return this;
	}

	public Name Build()
	{
		return new(_name);
	}
}
