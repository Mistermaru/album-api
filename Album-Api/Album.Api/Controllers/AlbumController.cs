using Microsoft.AspNetCore.Mvc;
using Album.Api.Services;
using Album.Api.Models;
using NpgsqlTypes;

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
        /// <returns>OkResult with a list of albums</returns>
        [HttpGet]
        public IActionResult GetAlbums()
        {
            var albums = _albumService.GetAll();
            return Ok(albums);
        }

        /// <summary>
        /// Get an album by ID.
        /// </summary>
        /// <returns>OkResult with an album by ID</returns>
        /// <response code="404">Not Found</response>
        [HttpGet("{id}", Name = "GetAlbumById")]
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
        /// Create a new album.
        /// </summary>
        /// <returns>A newly created album</returns>
        ///  <response code="400">Bad Request</response>
        ///  <response code="201 ">Album Created</response>
        [HttpPost]
        [ProducesResponseType(400)]
        public IActionResult CreateAlbum(AlbumModel albumModel)
        {
            if (albumModel.Name == null || albumModel.Artist == null || albumModel.ImageUrl == null)
            {
                return BadRequest();
            }
            
            _albumService.Create(albumModel);

            return CreatedAtAction("GetAlbumById", new { id = albumModel.Id }, albumModel);

        }

        /// <summary>
        /// Update an album.
        /// </summary>
        /// <returns>Ok Message</returns>
        /// <response code="400">Bad Request</response>
        /// <response code="200">Succes; Message: Album updated</response>
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
        /// Delete an album.
        /// </summary>
        /// <returns>No Content</returns>
        /// <response code="204">No Content</response>
        /// <response code="404">Not Found</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
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
