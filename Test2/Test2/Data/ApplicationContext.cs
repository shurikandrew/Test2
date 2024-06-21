using Microsoft.EntityFrameworkCore;
using Test2.Models;

namespace Test2.Data;

public class ApplicationContext : DbContext
{
    protected ApplicationContext()
    {
    }

    public ApplicationContext(DbContextOptions options) : base(options)
    {
    }
    
    public DbSet<Item> Items { get; set; }
    public DbSet<Backpack> Backpacks { get; set; }
    public DbSet<Character> Characters { get; set; }
    public DbSet<CharacterTitle> CharacterTitles { get; set; }
    public DbSet<Title> Titles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Item>().HasData(new List<Item>()
        {
            new()
            {
                Id = 1,
                Name = "Sword",
                Weight = 100
            },
            new()
            {
                Id = 2,
                Name = "Shield",
                Weight = 120
            },
            new()
            {
                Id = 3,
                Name = "Potion",
                Weight = 50
            }
        });
        modelBuilder.Entity<Backpack>().HasData(new List<Backpack>()
        {
            new()
            {
                CharacterId = 1,
                ItemId = 1,
                Amount = 1
            },
            new()
            {
                CharacterId = 2,
                ItemId = 3,
                Amount = 3
            },
            new()
            {
                CharacterId = 3,
                ItemId = 2,
                Amount = 1
            }
        });
        modelBuilder.Entity<Character>().HasData(new List<Character>()
        {
            new()
            {
                Id = 1,
                FirstName = "John",
                LastName = "Doe",
                CurrentWeight = 15,
                MaxWeight = 200
            },
            new()
            {
                Id = 2,
                FirstName = "Jack",
                LastName = "Jackson",
                CurrentWeight = 150,
                MaxWeight = 350
            },
            new()
            {
                Id = 3,
                FirstName = "Will",
                LastName = "Smith",
                CurrentWeight = 0,
                MaxWeight = 150
            }
        });
        modelBuilder.Entity<CharacterTitle>().HasData(new List<CharacterTitle>()
        {
            new()
            {
                CharacterId = 1,
                TitleId = 2,
                AcquiredAt = new DateTime(2020, 10, 12, 10, 12 ,0)
            },
            new()
            {
                CharacterId = 2,
                TitleId = 3,
                AcquiredAt = new DateTime(2018, 11, 1, 12, 2 ,13)
            },
            new()
            {
                CharacterId = 3,
                TitleId = 1,
                AcquiredAt = new DateTime(1990, 5, 5, 5, 10 ,0)
            }
        });
        modelBuilder.Entity<Title>().HasData(new List<Title>()
        {
            new()
            {
                Id = 1,
                Name = "Hunter"
            },
            new()
            {
                Id = 2,
                Name = "Tank"
            },
            new()
            {
                Id = 3,
                Name = "Fighter"
            }
        });
    }
}