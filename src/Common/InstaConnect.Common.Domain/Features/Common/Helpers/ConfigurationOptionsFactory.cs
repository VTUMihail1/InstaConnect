using InstaConnect.Common.Domain.Features.Common.Abstractions;
using InstaConnect.Common.Domain.Features.Common.Extensions;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace InstaConnect.Common.Domain.Features.Common.Helpers;

internal sealed class ConfigurationOptionsFactory<TOptions> : OptionsFactory<TOptions>
	where TOptions : class, IApplicationOptions
{
	private readonly IConfiguration _configuration;
	private readonly string _sectionName;

	public ConfigurationOptionsFactory(
		IConfiguration configuration,
		string sectionName,
		IEnumerable<IConfigureOptions<TOptions>> setups,
		IEnumerable<IPostConfigureOptions<TOptions>> postConfigures,
		IEnumerable<IValidateOptions<TOptions>> validations)
		: base(setups, postConfigures, validations)
	{
		_configuration = configuration;
		_sectionName = sectionName;
	}

	protected override TOptions CreateInstance(string name)
	{
		return _configuration.GetOptions<TOptions>(_sectionName);
	}
}
