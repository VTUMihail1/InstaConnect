namespace InstaConnect.Posts.Tests.Features.Users.Utilities;
public static class UserGenerator
{
    public static ICollection<User> GenerateRange(this User template)
    {
        const int Count = 50;

        return [.. Enumerable.Range(default, Count)
            .Select(_ => new User(new(UserDataFaker.GetId()),
                                  UserDataFaker.GetFirstNameWithPrefix(template.FirstName),
                                  UserDataFaker.GetLastNameWithPrefix(template.LastName),
                                  new(UserDataFaker.GetEmailWithPrefix(template.Email.Value)),
                                  new(UserDataFaker.GetNameWithPrefix(template.Name.Value)),
                                  new(UserDataFaker.GetProfileImage()),
                                  UserDataFaker.GetCreatedAtUtc(),
                                  UserDataFaker.GetUpdatedAtUtc()))];
    }
}
