using BigOn.Domain.Models.Entities.Membership;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BigOn.Domain.Models.DataContexts.Configurations.Membership
{
    internal class BigOnUserClaimEntityTypeConfiguration : IEntityTypeConfiguration<BigOnUserClaim>
    {
        public void Configure(EntityTypeBuilder<BigOnUserClaim> builder)
        {
            builder.ToTable("UserClaims", "Membership");
        }
    }
}
