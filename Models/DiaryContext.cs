using Microsoft.EntityFrameworkCore;

namespace DiaryAPI.Models;

public class DiaryContext : DbContext
{
    public DiaryContext(DbContextOptions<DiaryContext> options)
        : base(options)
    {
    }

    public DbSet<DiaryItems> DiaryItems { get; set; } = null!;
}
