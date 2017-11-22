using Microsoft.EntityFrameworkCore;
using EventBooking.Core.Entities.DatabaseModels;
using EventBooking.Core.Entities.DatabaseModels.ManyToMany;

namespace EventBooking.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        
        public DbSet<Image> Images { get; set; }
        
        public DbSet<Event> Events { get; set; }
        
        public DbSet<EventGuide> EventGuides { get; set; }
        
        public DbSet<EventParticipant> EventParticipants { get; set; }
        
        public DbSet<PreferencesSet> Preferences { get; set; }
        
        public DbSet<RightsSet> Rights { get; set; }

        public DbSet<Mails> Mails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<EventGuide>()
                .HasKey(t => new { t.EventId, t.GuideMail });
            
            modelBuilder.Entity<EventGuide>()
                .HasOne(pt => pt.Event)
                .WithMany(p => p.EventGuides)
                .HasForeignKey(pt => pt.EventId);
            
            modelBuilder.Entity<EventGuide>()
                .HasOne(pt => pt.Guide)
                .WithMany(t => t.GuidedEvents)
                .HasForeignKey(pt => pt.GuideMail);
            
            modelBuilder.Entity<EventParticipant>()
                .HasKey(t => new { t.EventId, t.ParticipantMail });
            
            modelBuilder.Entity<EventParticipant>()
                .HasOne(pt => pt.Event)
                .WithMany(p => p.EventParticipants)
                .HasForeignKey(pt => pt.EventId);
            
            modelBuilder.Entity<EventParticipant>()
                .HasOne(pt => pt.Participant)
                .WithMany(t => t.AttendedEvents)
                .HasForeignKey(pt => pt.ParticipantMail);
        }
    }
}
