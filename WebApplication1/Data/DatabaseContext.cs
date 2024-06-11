using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data;

public class DatabaseContext : DbContext
{
    public DatabaseContext()
    {
    }
    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }
    
    public DbSet<Item> Items { get; set; }
    public DbSet<Character> Characters { get; set; }
    public DbSet<Title> Titles { get; set; }
    public DbSet<Backpack> Backpacks { get; set; }
    public DbSet<Character_title> CharacterTitles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Item>().HasData(new List<Item>
            {
                new Item {
                    Id = 1,
                    Name = "Jan",
                    Weight = 50
                }
            });
    }
}