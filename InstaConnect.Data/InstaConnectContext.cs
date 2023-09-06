using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace InstaConnect.Data
{
    public class InstaConnectContext : IdentityDbContext
    {
        public InstaConnectContext(DbContextOptions<InstaConnectContext> options) : base(options)
        {  }
    }
}
