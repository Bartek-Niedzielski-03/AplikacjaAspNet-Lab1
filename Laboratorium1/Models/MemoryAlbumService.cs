using System.Collections.Generic;
using System.Linq;

namespace Laboratorium1.Models
{
    public class MemoryAlbumService : IAlbumService
    {
        private readonly IDateTimeProvider _timeProvider;
        private readonly Dictionary<int, Album> _items = new Dictionary<int, Album>();
        private int _id = 0;

        public void AddAlbum(Album album)
        {
            album.Created = _timeProvider.Now();
            album.Id = ++_id;
            _items.Add(album.Id, album);
        }

        public bool DeleteAlbumById(int id)
        {
            return _items.Remove(id);
        }

        public List<Album> GetAlbums()
        {
            return _items.Values.ToList();
        }

        public Album? GetAlbumById(int id)
        {
            return _items.TryGetValue(id, out var album) ? album : null;
        }

        public bool UpdateAlbum(Album album)
        {
            if (!_items.ContainsKey(album.Id)) return false;
            _items[album.Id] = album;
            return true;
        }
        
        public MemoryAlbumService(IDateTimeProvider timeProvider)
        {
            _timeProvider = timeProvider;
        }

    }
}