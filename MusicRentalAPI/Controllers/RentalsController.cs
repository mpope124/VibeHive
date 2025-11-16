using Microsoft.AspNetCore.Mvc;
using MusicRentalAPI.Data;
using MusicRentalAPI.Models;

namespace MusicRentalAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RentalsController : ControllerBase
    {
        // List all ACTIVE rentals (ReturnDate == null)
        [HttpGet]
        public ActionResult<IEnumerable<Rental>> GetActiveRentals()
        {
            var activeRentals = InMemoryDatabase.Rentals.Where(r => r.ReturnDate == null).ToList();
            return Ok(activeRentals);
        }

        // Rent an album by providing UserId and AlbumId
        [HttpPost]
        public ActionResult<Rental> RentAlbum([FromBody] Rental request)
        {
            if (request == null)
            {
                return BadRequest("Rental information is required.");
            }

            // Check that album exists
            var album = InMemoryDatabase.MusicAlbums.FirstOrDefault(a => a.Id == request.AlbumId);

            if (album == null)
            {
                return NotFound($"Album with Id {request.AlbumId} not found.");
            }

            // Check that album is available
            if (!album.Available)
            {
                return BadRequest("Album is not available for rent.");
            }

            // Generate rental Id
            int nextId = InMemoryDatabase.Rentals.Any()
                ? InMemoryDatabase.Rentals.Max(r => r.Id) + 1
                : 1;

            var rental = new Rental
            {
                Id = nextId,
                UserId = request.UserId,
                AlbumId = request.AlbumId,
                RentalDate = DateTime.Now,
                ReturnDate = null
            };

            // Mark album as unavailable
            album.Available = false;

            InMemoryDatabase.Rentals.Add(rental);

            // We add a GetById endpoint below to support CreatedAtAction
            return CreatedAtAction(nameof(GetById), new { id = rental.Id }, rental);
        }


        // Helper to fetch a single rental (used by CreatedAtAction)
        [HttpGet("{id}")]
        public ActionResult<Rental> GetById(int id)
        {
            var rental = InMemoryDatabase.Rentals.FirstOrDefault(r => r.Id == id);
            if (rental == null)
            {
                return NotFound();
            }

            return Ok(rental);
        }

        // Return a rented album
        [HttpPost("{id}/return")]
        public ActionResult<Rental> ReturnAlbum(int id)
        {
            var rental = InMemoryDatabase.Rentals.FirstOrDefault(r => r.Id == id);
            if (rental == null)
            {
                return NotFound($"Rental with Id {id} not found.");
            }

            if (rental.ReturnDate != null)
            {
                return BadRequest("This rental has already been returned.");
            }

            rental.ReturnDate = DateTime.Now;

            // Mark album as available again
            var album = InMemoryDatabase.MusicAlbums
                .FirstOrDefault(a => a.Id == rental.AlbumId);

            if (album != null)
            {
                album.Available = true;
            }

            return Ok(rental);
        }
    }
}
