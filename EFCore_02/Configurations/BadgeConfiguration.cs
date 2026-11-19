using EFCore_02.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore_02.Configurations
{
    internal class BadgeConfiguration : IEntityTypeConfiguration<Badge>
    {
        public void Configure(EntityTypeBuilder<Badge> builder)
        {
            builder.ToTable("Badges");
            builder.HasKey(x => x.BadgeId);
            builder.Property(x => x.BadgeNumber).IsRequired();
            builder.HasIndex(x => x.BadgeNumber).IsUnique();
            builder.Property(x => x.IssuedDate).IsRequired().HasDefaultValueSql("GETDATE()");
            builder.Property(x => x.Tier).IsRequired().HasConversion<string>().HasMaxLength(20);
        }
    }
}
