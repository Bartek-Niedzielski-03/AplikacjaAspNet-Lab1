using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace Data;

public class AppDbContext : DbContext
{
    public DbSet<AlbumEntity> Albums { get; set; }
    public DbSet<LabelEntity> Labels { get; set; }

    private string DbPath { get; set; }

    public AppDbContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "albums.db");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");

protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<LabelEntity>()
        .OwnsOne(l => l.Address);
    
    modelBuilder.Entity<AlbumEntity>()
        .HasOne(a => a.Label)
        .WithMany(l => l.Albums)
        .HasForeignKey(a => a.LabelId);

    //deafault
    modelBuilder.Entity<AlbumEntity>()
        .Property(a => a.LabelId)
        .HasDefaultValue(101);
    
    modelBuilder.Entity<AlbumEntity>()
        .Property(a => a.Created)
        .HasDefaultValueSql("CURRENT_TIMESTAMP");

    
    modelBuilder.Entity<LabelEntity>().HasData(
        new LabelEntity
        {
            Id = 101,
            Title = "Universal Music",
            Nip = "1111111111",
            Regon = "2222222222"
        },
        new LabelEntity
        {
            Id = 102,
            Title = "Sony Music",
            Nip = "3333333333",
            Regon = "4444444444"
        }
    );
    
    modelBuilder.Entity<LabelEntity>()
        .OwnsOne(l => l.Address)
        .HasData(
            new
            {
                LabelEntityId = 101,
                City = "Kraków",
                Street = "Św. Filipa 17",
                PostalCode = "31-150",
                Region = "małopolskie"
            },
            new
            {
                LabelEntityId = 102,
                City = "Warszawa",
                Street = "Marszałkowska 1",
                PostalCode = "00-001",
                Region = "mazowieckie"
            }
        );
    
    modelBuilder.Entity<AlbumEntity>().HasData(
        new AlbumEntity
        {
            Id = 1,
            Title = "Test Album",
            Artist = "Test Artist",
            List = "Track1; Track2",
            Position = 1,
            ReleaseDate = new DateTime(2020, 1, 1),
            Duration = 42,
            MusicType = 1,
            Created = new DateTime(2025, 1, 1),
            LabelId = 101
        }
    );
}

}