using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IAlbumRepository
    {
        Task<IEnumerable<Album>> GetAlbums();

        Task<Album> GetAlbumById(int id);

        Task<IEnumerable<Album>> GetUserAlbums(int userId);
    }
}
