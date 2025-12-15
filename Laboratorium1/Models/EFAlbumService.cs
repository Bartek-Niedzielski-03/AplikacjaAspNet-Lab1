using Data;
using Laboratorium1.Mappers;
using Microsoft.EntityFrameworkCore;

namespace Laboratorium1.Models;

public class EFAlbumService : IAlbumService
{
    private readonly AppDbContext _context;

    public EFAlbumService(AppDbContext context)
    {
        _context = context;
    }

    public void AddAlbum(Album album)
    {
        _context.Albums.Add(AlbumMapper.ToEntity(album));
        _context.SaveChanges();
    }

    public bool DeleteAlbumById(int id)
    {
        var entity = _context.Albums.Find(id);
        if (entity == null) return false;

        _context.Albums.Remove(entity);
        _context.SaveChanges();
        return true;
    }

    public List<Album> GetAlbums()
    {
        return _context.Albums
            .AsNoTracking()
            .Select(e => AlbumMapper.FromEntity(e))
            .ToList();
    }

    public Album? GetAlbumById(int id)
    {
        var entity = _context.Albums.AsNoTracking().FirstOrDefault(x => x.Id == id);
        return entity == null ? null : AlbumMapper.FromEntity(entity);
    }

    public bool UpdateAlbum(Album album)
    {
        if (!_context.Albums.Any(x => x.Id == album.Id)) return false;

        _context.Albums.Update(AlbumMapper.ToEntity(album));
        _context.SaveChanges();
        return true;
    }
}