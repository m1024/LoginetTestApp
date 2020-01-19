using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace TestApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [FormatFilter]
    public class AlbumsController : ControllerBase
    {
        AlbumService _albumService;
        public AlbumsController(AlbumService albumService)
        {
            _albumService = albumService;
        }


        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var albumsList = await _albumService.GetAlbums();
            if (albumsList.Any())
                return Ok(albumsList);
            else
                return new NotFoundObjectResult("Not found");
        }

        [HttpGet("{id}")]
        //[HttpGet("{id}.{format?}")]
        public async Task<IActionResult> GetById(int id)
        {
            var album = await _albumService.GetAlbumById(id);
            if (album != null)
                return Ok(album);
            else
                return new NotFoundObjectResult("Not found");
        }

        [HttpGet("user/{userId}")]
        //[HttpGet("user/{userId}.{format?}")]
        public async Task<IActionResult> GeUserAlbums(int userId)
        {
            var albums = await _albumService.GetUserAlbums(userId);
            if (albums.Any())
                return Ok(albums);
            else
                return new NotFoundObjectResult("Not found");
        }
    }
}