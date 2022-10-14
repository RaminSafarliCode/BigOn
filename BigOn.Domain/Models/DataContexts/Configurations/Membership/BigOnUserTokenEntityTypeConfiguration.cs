using BigOn.Domain.Models.Entities.Membership;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BigOn.Domain.Models.DataContexts.Configurations.Membership
{
    internal class BigOnUserTokenEntityTypeConfiguration : IEntityTypeConfiguration<BigOnUserToken>
    {
        public void Configure(EntityTypeBuilder<BigOnUserToken> builder)
        {
            builder.ToTable("UserTokens", "Membership");
        }
    }
}
