using BigOn.Domain.Models.Entities.Membership;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BigOn.Domain.Models.DataContexts.Configurations.Membership
{
    internal class BigOnRoleClaimEntityTypeConfiguration : IEntityTypeConfiguration<BigOnRoleClaim>
    {
        public void Configure(EntityTypeBuilder<BigOnRoleClaim> builder)
        {
            builder.ToTable("RoleClaims", "Membership");
        }
    }
}
