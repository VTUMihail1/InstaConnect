using System.ComponentModel.DataAnnotations;

using InstaConnect.Common.Domain.Features.Common.Abstractions;

namespace InstaConnect.Common.Infrastructure.Features.Data.Models;

public class MongoOptions : IApplicationOptions
{
	public const string SectionName = "MongoConfiguration";

	[Required]
	public string ConnectionString { get; set; } = string.Empty;

	[Required]
	public string Name { get; set; } = string.Empty;
}
