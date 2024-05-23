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
    public DbSet<Admin> Admin { get; set; } = null!;
    public DbSet<StoriesToReadLater> StoriesToReadLater { get; set; } = null!;
    public DbSet<Notification> Notifications { get; set; } = null!;

    public ApplicationDbContext()
    {
        // Database.EnsureDeleted();
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
        // Seed Admin
        modelBuilder.Entity<Admin>().HasData(new Admin{Id = 1, Name = "Admin", Password = "12345678"});
        
        // Seed Writers
        modelBuilder.Entity<Writer>().HasData(
            new Writer { Id = 1, Name = "bigfoot", IsBanned = false, Age = 34, Password = "12345678"},
            
            new Writer { Id = 2, Name = "lalala", IsBanned = false, Age = 26,  Password = "12345678"}
        );

        // Seed Shows
        modelBuilder.Entity<Show>().HasData(
            new Show { Id = 1, Name = "Walking Dead" },
            new Show { Id = 2, Name = "Fleabag" }
        );

        // Seed Genres
        modelBuilder.Entity<Genre>().HasData(
            new Genre {Id = 1, Name = "Action", AgeLimit = 16 },
            new Genre {Id = 2, Name = "Adventure", AgeLimit = 16 },
            new Genre {Id = 3, Name = "Comedy", AgeLimit = 16 },
            new Genre {Id = 4, Name = "Crime", AgeLimit = 18 },
            new Genre {Id = 5, Name = "Thriller", AgeLimit = 18 },
            new Genre {Id = 6, Name = "Fantasy", AgeLimit = 16 },
            new Genre {Id = 7, Name = "Horror", AgeLimit = 16 },
            new Genre {Id = 8, Name = "Romance", AgeLimit = 16 }
        );

        // Seed Stories
        modelBuilder.Entity<Story>().HasData(
            new Story { Id = 1, Title = "East of Alexandria", Content = "The war with Negan is over. The leaders struck a " +
                                                                        "deal with each other; the communities no longer " +
                                                                        "serve Negan and he gets to live under one condition…the " +
                                                                        "communities can never have any contact with The " +
                                                                        "Sanctuary and vice versa. Everything is good " +
                                                                        "until…Rick's daughter forms a relationship with a guy " +
                                                                        "she meets on the outside, who happens to be a savior. " +
                                                                        "Another Abby spin-off.", 
                WriterId = 1, ShowId = 1, GenreId = 2, ImageSource = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS3eraADCg860k7mSlT-douktUWad5xmXm8Hgy5ZF97OQ&s"},
            new Story { Id = 2, Title = "Just come home", Content = "Josey Kowalski & Grandfather Walt never fit into the white " +
                                                            "picket fence paradise Alexandria " +
                                                            "was once sold as. Despite initial differences, " +
                                                            "Rick and Josey find themselves together... " +
                                                            "then tragedy strikes. Five years later, " +
                                                            "Josey returns to Alexandria & things aren't as clear " +
                                                            "cut as before as she reunites with Daryl " +
                                                            "& the others ..." +
                                                            "for publication in another journal.",
                WriterId = 2, ShowId = 1, GenreId = 8, ImageSource = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSojYhf7F5A9BvDALPcVbt59_heJZIHFK124BpcOXZeZA&s"},
            new Story { Id = 3, Title = "From hell with love", Content = "She's already used to signing like this. " +
                                                                         "Although everyone just calls her Helly. " +
                                                                         "But damn, it sounds so American. She didn't like it. Not even that," +
                                                                         " but the fact that the name sounded too sweet, childish, too cute. " +
                                                                         "In fact, her name is spelled “Hel” in documents, but Americans " +
                                                                         "don’t pronounce the “l” sound at the end of words " +
                                                                         "(and it’s not easy to explain to everyone that " +
                                                                         "the name is spelled with one letter “l”), so everyone " +
                                                                         "calls her Helly ( because “Damn”** sounds offensive, " +
                                                                         "and in the USA you have to be very careful with insults lately). " +
                                                                         "The girl has to endure this every day.", 
                WriterId = 1, ShowId = 2, GenreId = 8, ImageSource = "https://m.media-amazon.com/images/I/71AJoBx3oDL._AC_UF894,1000_QL80_.jpg"},
            new Story { Id = 4, Title = "Close Encounters of the Priest Kind", Content = "My morning goes by quite calmly, but by lunchtime, " +
                    "right in the hustle and bustle of work, " +
                    "the largest bouquet of flowers that " +
                    "I have ever been given arrived. " +
                    "The card simply says, \"Happy Birthday.\""
                , WriterId = 2, ShowId = 2, GenreId = 2, ImageSource = "https://blob.cede.ch/catalog/16673000/16673742_1_92.jpg?v=1"}
        );
    }
}