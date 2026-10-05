using InstaConnect.Common.Domain.Features.ValueObjects.Models;
using InstaConnect.Common.Tests.Features.DataAttributes.Base;
using InstaConnect.Common.Tests.Features.DataAttributes.Strings.Base;

namespace InstaConnect.Common.Infrastructure.Tests.Features.Builders;

public class EmailBuilder
{
	private string _email;

	public EmailBuilder(Email email)
	{
		_email = email.Value;
	}

	public EmailBuilder WithEmail(Email email, IStringTransformer? transformer = null)
	{
		_email = transformer.TryTransform(email.Value);

		return this;
	}

	public EmailBuilder WithEmail(IStringTransformer transformer)
	{
		_email = transformer.Transform(_email);

		return this;
	}

	public Email Build()
	{
		return new(_email);
	}
}
