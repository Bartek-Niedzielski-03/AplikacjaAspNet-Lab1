using Data;
using Data.Entities;
using Laboratorium1.Mappers;
using Microsoft.EntityFrameworkCore;

namespace Laboratorium1.Models;

public class EFAlbumService : IAlbumService
{
    private readonly AppDbContext _context;
    private readonly IDateTimeProvider _timeProvider;

    public EFAlbumService(AppDbContext context, IDateTimeProvider timeProvider)
    {
        _context = context;
        _timeProvider = timeProvider;
    }

    public void AddAlbum(Album album)
    {
        if (album.Created == default)
        {
            album.Created = _timeProvider.Now();
        }

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
            .Include(a => a.Label)
            .Select(e => AlbumMapper.FromEntity(e))
            .ToList();
    }

    public Album? GetAlbumById(int id)
    {
        var entity = _context.Albums
            .AsNoTracking()
            .Include(a => a.Label)
            .FirstOrDefault(a => a.Id == id);

        return entity == null ? null : AlbumMapper.FromEntity(entity);
    }

    public bool UpdateAlbum(Album album)
    {
        if (!_context.Albums.Any(x => x.Id == album.Id)) return false;

        _context.Albums.Update(AlbumMapper.ToEntity(album));
        _context.SaveChanges();
        return true;
    }
    public List<LabelEntity> FindAllLabels()
    {
        return _context.Labels.ToList();
    }
}