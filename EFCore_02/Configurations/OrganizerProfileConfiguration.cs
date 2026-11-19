using EFCore_02.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore_02.Configurations
{
    internal class OrganizerProfileConfiguration : IEntityTypeConfiguration<OrganizerProfile>
    {
        public void Configure(EntityTypeBuilder<OrganizerProfile> builder)
        {
            builder.HasKey(x => x.ProfileId);
            builder.Property(x => x.Biography).HasMaxLength(500);
            builder.Property(x => x.WebsiteUrl).HasMaxLength(300);
            builder.Property(x => x.Logo).HasMaxLength(300);
        }
    }
}
