using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SleepMonitor.Domain.Entities;

namespace SleepMonitor.Infrastructure.Persistence;

internal class SleepMonitorDbContext(DbContextOptions<SleepMonitorDbContext> options) : IdentityDbContext<User>(options)
{
    internal DbSet<SleepRecord> SleepRecords { get; set; }
    internal DbSet<IoTData> IoTData { get; set; }
    internal DbSet<Recommendation> Recommendations { get; set;}
    internal DbSet<SleepRecord_Recommendation> SleepRecord_Recommendations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<SleepRecord>()
            .HasOne(sr => sr.User)
            .WithMany(u => u.SleepRecords)
            .HasForeignKey(sr => sr.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<IoTData>()
            .HasOne(iot => iot.User)
            .WithMany(u => u.IoTData)
            .HasForeignKey(iot => iot.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<SleepRecord_Recommendation>()
            .HasKey(srr => new { srr.SleepRecordId, srr.RecommendationId });

        modelBuilder.Entity<SleepRecord_Recommendation>()
            .HasOne(srr => srr.SleepRecord)
            .WithMany(sr => sr.SleepRecordRecommendations)
            .HasForeignKey(srr => srr.SleepRecordId);

        modelBuilder.Entity<SleepRecord_Recommendation>()
            .HasOne(srr => srr.Recommendation)
            .WithMany()
            .HasForeignKey(srr => srr.RecommendationId);
    }
}
 