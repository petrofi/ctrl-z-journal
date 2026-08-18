using CtrlZJournal.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace CtrlZJournal.Infrastructure.Persistence;

public class CtrlZJournalDbContext : DbContext
{
    public DbSet<WorkEntry> WorkEntries => Set<WorkEntry>();

    public CtrlZJournalDbContext(
        DbContextOptions<CtrlZJournalDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<WorkEntry>(entity =>
        {
            entity.HasKey(entry => entry.Id);

            entity.Property(entry => entry.Title)
                .HasMaxLength(100)
                .IsRequired();

            entity.Property(entry => entry.WorkDescription)
                .HasMaxLength(2000)
                .IsRequired();
      
      
      
        });
    }
}






























