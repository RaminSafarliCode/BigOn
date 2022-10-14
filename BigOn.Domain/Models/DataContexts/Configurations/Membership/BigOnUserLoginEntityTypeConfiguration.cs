using BigOn.Domain.Models.Entities.Membership;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BigOn.Domain.Models.DataContexts.Configurations.Membership
{
    internal class BigOnUserLoginEntityTypeConfiguration : IEntityTypeConfiguration<BigOnUserLogin>
    {
        public void Configure(EntityTypeBuilder<BigOnUserLogin> builder)
        {
            builder.ToTable("UserLogins", "Membership");
        }
    }
}
