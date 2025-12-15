using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace Data;

public class AppDbContext : DbContext
{
    public DbSet<AlbumEntity> Albums { get; set; }

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
                Created = new DateTime(2025, 1, 1)
            }
        );
    }
}