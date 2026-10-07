using FluentValidation;

using InstaConnect.Common.Domain.Features.Common.Abstractions;

using Microsoft.Extensions.Options;

namespace InstaConnect.Common.Domain.Features.Common.Helpers;

internal sealed class FluentValidationOptionsValidator<TOptions> : IValidateOptions<TOptions>
	where TOptions : class, IApplicationOptions
{
	private readonly IValidator<TOptions> _validator;

	public FluentValidationOptionsValidator(IValidator<TOptions> validator)
	{
		_validator = validator;
	}

	public ValidateOptionsResult Validate(string? name, TOptions options)
	{
		var result = _validator.Validate(options);

		if (result.IsValid)
		{
			return ValidateOptionsResult.Success;
		}

		var failures = result.Errors.Select(error => $"{typeof(TOptions).Name}: {error.ErrorMessage}");

		return ValidateOptionsResult.Fail(failures);
	}
}
