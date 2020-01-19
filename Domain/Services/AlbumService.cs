using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class AlbumService
    {
        private IAlbumRepository _albumRepository;

        public AlbumService(IAlbumRepository albumRepository)
        {
            _albumRepository = albumRepository;
        }

        public async Task<Album> GetAlbumById(int id)
        {
            return await _albumRepository.GetAlbumById(id);
        }

        public async Task<IEnumerable<Album>> GetAlbums()
        {
            return await _albumRepository.GetAlbums();
        }

        public async Task<IEnumerable<Album>> GetUserAlbums(int userId)
        {
            return await _albumRepository.GetUserAlbums(userId);
        }
    }
}
