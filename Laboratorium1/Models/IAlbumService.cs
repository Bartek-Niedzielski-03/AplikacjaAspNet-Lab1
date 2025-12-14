using System.Collections.Generic;

namespace Laboratorium1.Models
{
    public interface IAlbumService
    {
        void AddAlbum(Album album);
        bool DeleteAlbumById(int id);
        bool UpdateAlbum(Album album);
        List<Album> GetAlbums();
        Album? GetAlbumById(int id);
    }
}