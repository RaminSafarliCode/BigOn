using BigOn.Domain.Models.Entities.Membership;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BigOn.Domain.Models.DataContexts.Configurations.Membership
{
    internal class BigOnUserRoleEntityTypeConfiguration : IEntityTypeConfiguration<BigOnUserRole>
    {
        public void Configure(EntityTypeBuilder<BigOnUserRole> builder)
        {
            builder.ToTable("UserRoles", "Membership");
        }
    }
}
