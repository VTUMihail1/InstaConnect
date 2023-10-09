using InstaConnect.Data.Abstraction.Helpers;
using InstaConnect.Data.Models.Entities;
using Microsoft.AspNetCore.Identity;

namespace InstaConnect.Data.Helpers
{
    public class InstaConnectSignInManager : IInstaConnectSignInManager
    {
        private readonly SignInManager<User> _signInManager;

        public InstaConnectSignInManager(SignInManager<User> signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task<SignInResult> PasswordSignInAsync(User user, string password, bool isPersistent, bool lockoutOnFailure)
        {
            var signInResult = await _signInManager.PasswordSignInAsync(user, password, isPersistent, lockoutOnFailure);

            return signInResult;
        }
    }
}
