using Microsoft.AspNetCore.Mvc;
using MusicRentalAPI.Data;
using MusicRentalAPI.Models;

namespace MusicRentalAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MusicController : ControllerBase
    {


        [HttpGet]
        public ActionResult<IEnumerable<Music>> GetAll()
        {
            return Ok(InMemoryDatabase.MusicAlbums);
        }


        [HttpPost]
        public ActionResult<Music> Create([FromBody] Music newAlbum)
        {
            if (newAlbum == null)
            {
                return BadRequest("Album data is required.");
            }

            // Simple Id generation: max Id + 1
            int nextId = InMemoryDatabase.MusicAlbums.Any()
                ? InMemoryDatabase.MusicAlbums.Max(a => a.Id) + 1
                : 1;

            newAlbum.Id = nextId;

            // By default, new albums are available
            newAlbum.Available = true;

            InMemoryDatabase.MusicAlbums.Add(newAlbum);

            // Returns 201 Created with route to GET the new album
            return CreatedAtAction(nameof(GetById), new { id = newAlbum.Id }, newAlbum);
        }

        [HttpGet("{id}")]
        public ActionResult<Music> GetById(int id)
        {
            var album = InMemoryDatabase.MusicAlbums.FirstOrDefault(a => a.Id == id);
            if (album == null)
            {
                return NotFound();
            }

            return Ok(album);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var album = InMemoryDatabase.MusicAlbums.FirstOrDefault(a => a.Id == id);
            if (album == null)
            {
                return NotFound();
            }

            // If album is rented, this prevents it from being deleted.
            bool isRented = InMemoryDatabase.Rentals.Any(r => r.AlbumId == id && r.ReturnDate == null);
            if (isRented)
            {
                return BadRequest("Cannot delete an album that is currently rented.");
            }

            InMemoryDatabase.MusicAlbums.Remove(album);
            return NoContent();
        }
    }
}
