using BigOn.Domain.Models.Entities.Membership;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BigOn.Domain.Models.DataContexts.Configurations.Membership
{
    internal class BigOnRoleEntityTypeConfiguration : IEntityTypeConfiguration<BigOnRole>
    {
        public void Configure(EntityTypeBuilder<BigOnRole> builder)
        {
            builder.ToTable("Roles", "Membership");
        }
    }
}
