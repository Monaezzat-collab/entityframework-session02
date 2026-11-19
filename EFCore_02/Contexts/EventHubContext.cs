using EFCore_02.Configurations;
using EFCore_02.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore_02.Contexts
{
    internal class EventHubContext:DbContext
    {
        public DbSet<Organizer> Organizers { get; set; }
        public DbSet<OrganizerProfile> OrganizerProfiles { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Attendee> Attendees { get; set; }
        public DbSet<Badge> Badges { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=IDEAPAD-SLIM3;Database=BookStoreDb;Trusted_Connection=true;TrustServerCertificate=true");

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Separate configuration classes
            modelBuilder.ApplyConfiguration(new BadgeConfiguration());
            modelBuilder.ApplyConfiguration(new EventConfiguration());
            //modelBuilder.ApplyConfiguration(new OrganizerProfileConfiguration());
            #endregion

            #region Default, Directly In OnModelCreating

            //modelBuilder.Entity<Badge>(b =>
            //{

            //    b.ToTable("Badges");
            //    b.HasKey(x => x.BadgeId);
            //    b.Property(x => x.BadgeNumber).IsRequired();
            //    b.HasIndex(x => x.BadgeNumber).IsUnique();
            //    b.Property(x => x.IssuedDate).IsRequired();
            //    b.Property(x => x.Tier).IsRequired().HasConversion<string>().HasMaxLength(20);
            //});


            //modelBuilder.Entity<Event>(e =>
            //{

            //    e.HasKey(x => x.EventId);
            //    e.Property(x => x.Title).IsRequired().HasMaxLength(500);
            //    e.Property(x => x.Description).IsRequired().HasMaxLength(500);
            //    e.Property(x => x.StartDate).IsRequired();
            //    e.Property(x => x.EndDate).IsRequired(false);
            //    e.Property(x => x.MaxAttendees).IsRequired();
            //});


            modelBuilder.Entity<OrganizerProfile>(p =>
            {
                p.HasKey(x => x.ProfileId);
                p.Property(x => x.Biography).HasMaxLength(500);
                p.Property(x => x.WebsiteUrl).HasMaxLength(300);
                p.Property(x => x.Logo).HasMaxLength(300);
            });

            #endregion

        }
    }
}
