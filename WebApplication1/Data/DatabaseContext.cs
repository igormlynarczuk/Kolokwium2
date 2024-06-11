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
    public DbSet<CharacterTitle> CharacterTitles { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Backpack>()
            .HasKey(b => new { b.CharacterId, b.ItemId });
        modelBuilder.Entity<CharacterTitle>()
            .HasKey(ct => new { ct.CharacterId, ct.TitleId });
    }
}