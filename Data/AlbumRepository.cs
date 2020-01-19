using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using Data.Models;
using Domain.Interfaces;
using Domain.Models;

namespace Data
{
    public class AlbumRepository : IAlbumRepository
    {
        public AlbumRepository()
        {

        }

        private static IEnumerable<AlbumData> _albums;

        private async Task<IEnumerable<AlbumData>> GetAlbumsAsync(string url = "http://jsonplaceholder.typicode.com/albums")
        {
            if (_albums != null) return _albums; //по идее кешировать не надо, но тут данные неизменяемые

            var json = await RemoteJsonLoader.Load(url);
            return _albums = JsonSerializer.Deserialize<IEnumerable<AlbumData>>(json);
        }

        public async Task<Album> GetAlbumById(int id)
        {
            var albums = await GetAlbumsAsync();
            var album = albums.FirstOrDefault(u => u.Id == id);
            return album == null ? null : new Album() { Id = album.Id, Title = album.Title, UserId = album.UserId };
        }

        public async Task<IEnumerable<Album>> GetAlbums()
        {
            var albums = await GetAlbumsAsync();
            return albums.Select(u => new Album() { Id = u.Id, Title = u.Title, UserId = u.UserId }).ToList();
        }

        public async Task<IEnumerable<Album>> GetUserAlbums(int userId) 
        {
            var albums = await GetAlbumsAsync();
            return albums.Where(u => u.UserId == userId).Select(u => new Album() { Id = u.Id, Title = u.Title, UserId = u.UserId }).ToList();
        }
    }
}
