using InstaConnect.Shared.Business.Exceptions.Account;
using InstaConnect.Users.Business.Abstractions;
using InstaConnect.Users.Business.Extensions;
using InstaConnect.Users.Business.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstaConnect.Users.Business.Helpers
{
    public class CurrentUserContext : ICurrentUserContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUserContext(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public UserDetailsViewDTO GetUserDetails()
        {
            return new()
            {
                Id = _httpContextAccessor?.HttpContext.User.GetUserId() ?? throw new AccountUnauthorizedException()
            };
        }
    }
}
