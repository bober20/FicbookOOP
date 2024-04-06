using Ficbook.ModelsEF;
using Microsoft.EntityFrameworkCore;

namespace Ficbook.Services;

public sealed class ApplicationDbContext : DbContext
{
    public DbSet<Writer> Writers { get; set; } = null!;
    public DbSet<Story> Stories { get; set; } = null!;
    public DbSet<Show> Shows { get; set; } = null!;
    public DbSet<Genre> Genres { get; set; } = null!;
    public DbSet<Comment> Comments { get; set; } = null!;

    public ApplicationDbContext()
    {
        Database.EnsureCreated();
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string connectionDb = $"Filename={PathDb.GetPath("ficbook.db")}";
        
        optionsBuilder.UseSqlite(connectionDb);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        SeedData(modelBuilder);
    }

    private void SeedData(ModelBuilder modelBuilder)
    {
        // Seed Writers
        modelBuilder.Entity<Writer>().HasData(
            new Writer { Id = 1, Name = "Writer1", IsBanned = false, IsAdmin = false, Age = 18 },
            new Writer { Id = 2, Name = "Writer2", IsBanned = false, IsAdmin = false, Age = 18 }
        );

        // Seed Shows
        modelBuilder.Entity<Show>().HasData(
            new Show { Id = 1, Name = "Show1" },
            new Show { Id = 2, Name = "Show2" }
        );

        // Seed Genres
        modelBuilder.Entity<Genre>().HasData(
            new Genre { Id = 1, Name = "Genre1", AgeLimit = 18 },
            new Genre { Id = 2, Name = "Genre2", AgeLimit = 18 }
        );

        // Seed Stories
        modelBuilder.Entity<Story>().HasData(
            new Story { Id = 1, Title = "Story1", Content = "Content0", WriterId = 1, ShowId = 1, GenreId = 1 },
            new Story { Id = 2, Title = "Story2", Content = "Content1", WriterId = 1, ShowId = 2, GenreId = 1 },
            new Story { Id = 3, Title = "Story3", Content = "Content2", WriterId = 2, ShowId = 1, GenreId = 1 },
            new Story { Id = 4, Title = "Story4", Content = "Content3", WriterId = 2, ShowId = 2, GenreId = 2 }
        );
    }
}