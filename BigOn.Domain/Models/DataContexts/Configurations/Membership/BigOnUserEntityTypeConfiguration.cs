using BigOn.Domain.Models.Entities.Membership;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigOn.Domain.Models.DataContexts.Configurations.Membership
{
    internal class BigOnUserEntityTypeConfiguration : IEntityTypeConfiguration<BigOnUser>
    {
        public void Configure(EntityTypeBuilder<BigOnUser> builder)
        {
            builder.ToTable("Users", "Membership");
        }
    }
}
