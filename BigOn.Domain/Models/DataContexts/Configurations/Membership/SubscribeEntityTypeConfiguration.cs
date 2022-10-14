using BigOn.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigOn.Domain.Models.DataContexts.Configurations.Membership
{
    internal class SubscribeEntityTypeConfiguration : IEntityTypeConfiguration<Subscribe>
    {
        public void Configure(EntityTypeBuilder<Subscribe> builder)
        {
            builder.Property(t => t.Email)
                .IsRequired();

            builder.HasIndex(t => t.Email)
                .IsUnique();
        }
    }
}
