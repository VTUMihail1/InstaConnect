namespace InstaConnect.Follows.Domain.Features.Users.Models.Entities;

public class User : IEntityWithId<UserId>
{
	private User()
	{
		Id = new(string.Empty);
		FirstName = string.Empty;
		LastName = string.Empty;
		Email = new(string.Empty);
		Name = new(string.Empty);
		FollowFollowers = [];
		FollowFollowings = [];
	}

	public User(
		UserId id,
		string firstName,
		string lastName,
		Email email,
		Name name,
		Image? profileImage,
		DateTimeOffset createdAtUtc,
		DateTimeOffset updatedAtUtc)
	{
		Id = id;
		FirstName = firstName;
		LastName = lastName;
		Email = email;
		Name = name;
		ProfileImage = profileImage;
		FollowFollowers = [];
		FollowFollowings = [];
		CreatedAtUtc = createdAtUtc;
		UpdatedAtUtc = updatedAtUtc;
	}

	public UserId Id { get; }

	public string FirstName { get; private set; }

	public string LastName { get; private set; }

	public Email Email { get; private set; }

	public Name Name { get; private set; }

	public Image? ProfileImage { get; private set; }

	public ICollection<Follow> FollowFollowers { get; private set; }

	public ICollection<Follow> FollowFollowings { get; private set; }

	public DateTimeOffset CreatedAtUtc { get; }

	public DateTimeOffset UpdatedAtUtc { get; private set; }

	public void Update(
		Email email,
		string firstName,
		string lastName,
		Name name,
		Image? profileImage,
		DateTimeOffset updatedAtUtc)
	{
		Email = email;
		FirstName = firstName;
		LastName = lastName;
		Name = name;
		ProfileImage = profileImage;
		UpdatedAtUtc = updatedAtUtc;
	}

	public User AddFollowFollower(Follow followFollower)
	{
		FollowFollowers.Add(followFollower);

		return this;
	}

	public User AddFollowFollowing(Follow followFollowing)
	{
		FollowFollowings.Add(followFollowing);

		return this;
	}
}


