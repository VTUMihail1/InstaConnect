namespace InstaConnect.Posts.Tests.Features.Users.Utilities;
public static class UserGenerator
{
    public static ICollection<User> GenerateUsersRange(this User template)
    {
        const int NumberOfIterations = 50;

        return [.. Enumerable.Range(default, NumberOfIterations)
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
