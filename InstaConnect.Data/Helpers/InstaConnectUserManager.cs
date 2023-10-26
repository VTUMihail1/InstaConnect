using InstaConnect.Data.Abstraction.Helpers;
using InstaConnect.Data.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace InstaConnect.Data.Helpers
{
    public class InstaConnectUserManager : UserManager<User>, IInstaConnectUserManager
    {
        public InstaConnectUserManager(
            IUserStore<User> store, 
            IOptions<IdentityOptions> optionsAccessor, 
            IPasswordHasher<User> passwordHasher, 
            IEnumerable<IUserValidator<User>> userValidators, 
            IEnumerable<IPasswordValidator<User>> passwordValidators, 
            ILookupNormalizer keyNormalizer, 
            IdentityErrorDescriber errors, 
            IServiceProvider services, 
            ILogger<UserManager<User>> logger) : 
            base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger)
        {
        }

        public async Task ConfirmEmailAsync(User user)
        {
             await Users
                    .Where(u => u.Id == user.Id)
                    .ExecuteUpdateAsync(u => u.SetProperty(u => u.EmailConfirmed, true));
        }

        public async Task ResetPasswordAsync(User user, string password)
        {
            var passwordHash = PasswordHasher.HashPassword(user, password);

            await Users
                 .Where(u => u.Id == user.Id)
                 .ExecuteUpdateAsync(u => u.SetProperty(u => u.PasswordHash, passwordHash));
        }
    }
}
