using Authors.Api.Models;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
 
    public DbSet<Author> Authors { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    base.OnModelCreating(modelBuilder);

    modelBuilder.Entity<Author>(entity =>
    {
        entity.Property(e => e.Birth)
              .HasColumnType("timestamp with time zone") // Ensures no timezone info
              .HasConversion(
                  v => v.ToUniversalTime(), // Converts to UTC when saving
                  v => DateTime.SpecifyKind(v, DateTimeKind.Utc)); // Assumes UTC when reading
    });
}
}
