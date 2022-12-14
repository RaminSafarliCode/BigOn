using BigOn.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigOn.Domain.Models.DataContexts.Configurations
{
    internal class ContactPostEntityTypeConfiguration : IEntityTypeConfiguration<ContactPost>
    {
        public void Configure(EntityTypeBuilder<ContactPost> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasIndex(x => x.Email);

            builder.Property(x => x.Id)
                .UseIdentityColumn();

            builder.Property(x => x.Name)
                .IsRequired();

            builder.Property(x => x.Email)
                .IsRequired();

            builder.Property(x => x.Subject)
                .IsRequired();

            builder.Property(x => x.Message)
                .IsRequired();
        }
    }
}
