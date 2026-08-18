using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CtrlZJournal.Infrastructure.Persistence;

public class CtrlZJournalDbContextFactory
    : IDesignTimeDbContextFactory<CtrlZJournalDbContext>
{
    public CtrlZJournalDbContext CreateDbContext(string[] args)
    {
        DbContextOptionsBuilder<CtrlZJournalDbContext> optionsBuilder =
            new DbContextOptionsBuilder<CtrlZJournalDbContext>();

        optionsBuilder.UseSqlite(
            "Data Source=ctrlzjournal.db");

        return new CtrlZJournalDbContext(
            optionsBuilder.Options);
    }
}