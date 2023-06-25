using Microsoft.AspNetCore.Mvc;
using Album.Api.Services;
using Album.Api.Data;
using Album.Api.Models;

namespace Album.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumController : Controller
    {
        private readonly IAlbumService<AlbumModel> _albumService;

        public AlbumController(IAlbumService<AlbumModel> albumService)
        {
            _albumService = albumService;
        }

        /// <summary>
        /// Get a list of albums.
        /// </summary>
        /// <returns>A list of albums</returns>
        [HttpGet]
        public IActionResult GetAlbums()
        {
            var albums = _albumService.GetAll();
            return Ok(albums);
        }

        /// <summary>
        /// Get an album by ID.
        /// </summary>
        /// <returns>An album by ID</returns>
        [HttpGet("{id}")]
        public IActionResult GetAlbumById(int id)
        {
            var album = _albumService.GetById(id);
            if (album == null)
            {
                return NotFound();
            }

            return Ok(album);

        }

        /// <summary>
        /// Creates a new album.
        /// </summary>
        /// <returns>A newly created album</returns>
        [HttpPost]
        public IActionResult CreateAlbum(AlbumModel albumModel)
        {
            if (albumModel.Name == null || albumModel.Artist == null || albumModel.ImageUrl == null)
            {
                return BadRequest();
            }

            _albumService.Create(albumModel);

            return CreatedAtAction("GetAlbumModel", new { id = albumModel.Id }, albumModel);

        }

        /// <summary>
        /// Updates an album.
        /// </summary>
        /// <returns>Ok Message</returns>
        [HttpPut("{id}")]
        public IActionResult UpdateAlbum(int id, AlbumModel albumModel)
        {
            if (albumModel.Name == null || albumModel.Artist == null || albumModel.ImageUrl == null)
            {
                return BadRequest();
            }

            _albumService.Update(id, albumModel);
           
            return Ok(new { message = "Album updated" });
        }

        /// <summary>
        /// Deletes an album.
        /// </summary>
        /// <returns>No content</returns>
        [HttpDelete("{id}")]
        public IActionResult DeleteAlbum(int id)
        {
            var album = _albumService.GetById(id);

            if (album == null)
            {
                return NotFound();
            }

            _albumService.Delete(id);
            return NoContent();
        }
    }
}
