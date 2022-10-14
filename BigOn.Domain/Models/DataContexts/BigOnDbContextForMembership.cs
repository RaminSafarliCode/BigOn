using BigOn.Domain.Models.Entities;
using BigOn.Domain.Models.Entities.Membership;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BigOn.Domain.Models.DataContexts
{
    public partial class BigOnDbContext {
        public DbSet<BigOnRole> Roles { get; set; }
        public DbSet<BigOnRoleClaim> RoleClaims { get; set; }
        public DbSet<BigOnUser> Users { get; set; }
        public DbSet<BigOnUserClaim> UserClaims { get; set; }
        public DbSet<BigOnUserLogin> UserLogins { get; set; }
        public DbSet<BigOnUserRole> UserRoles { get; set; }
        public DbSet<BigOnUserToken> UserTokens { get; set; }
    }
}
