using DocConnect.Data.Models.Entities.Base;
using Microsoft.AspNetCore.Identity;

namespace DocConnect.Data.Models.Entities
{
    public class UserClaim : IdentityUserClaim<string>, IAuditableInfo
    {
        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
