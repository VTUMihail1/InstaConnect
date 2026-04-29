using InstaConnect.Identity.Events.Features.Users;

using Mapster;

namespace InstaConnect.Posts.Domain.Features.Users.Mappings;

internal class UserDomainMappings : IRegister
{
	public void Register(TypeAdapterConfig config)
	{
		config.NewConfig<User, UserEventRequest>()
			.ConstructUsing(src => new(
				src.Id.Id,
				src.Name.Value,
				src.Email.Value,
				src.FirstName,
				src.LastName,
				src.ProfileImage == null ? null : src.ProfileImage.Url,
				src.CreatedAtUtc,
				src.UpdatedAtUtc));
	}
}
