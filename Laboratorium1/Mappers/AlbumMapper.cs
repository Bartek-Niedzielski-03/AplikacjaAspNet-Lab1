using Data.Entities;
using Laboratorium1.Models;

namespace Laboratorium1.Mappers;

public static class AlbumMapper
{
    public static Album FromEntity(AlbumEntity e)
    {
        return new Album
        {
            Id = e.Id,
            Title = e.Title,
            Artist = e.Artist,
            List = e.List ?? "",
            Position = e.Position,
            ReleaseDate = e.ReleaseDate,
            Duration = e.Duration,
            MusicType = (MusicType)e.MusicType,
            Created = e.Created
        };
    }

    public static AlbumEntity ToEntity(Album m)
    {
        return new AlbumEntity
        {
            Id = m.Id,
            Title = m.Title,
            Artist = m.Artist,
            List = string.IsNullOrWhiteSpace(m.List) ? null : m.List,
            Position = m.Position,
            ReleaseDate = m.ReleaseDate,
            Duration = m.Duration,
            MusicType = (int)m.MusicType,
            Created = m.Created
        };
    }
}