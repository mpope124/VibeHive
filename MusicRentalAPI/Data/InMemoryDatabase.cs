using MusicRentalAPI.Models;

namespace MusicRentalAPI.Data
{
    public class InMemoryDatabase
    {
        // List of albums
        public static List<Music> MusicAlbums { get; } = new List<Music>
        {
            // Some sample data
            new Music { Id = 1, Title = "Thriller",   Artist = "Michael Jackson", Genre = "Pop",  Year = 1982, Available = true },
            new Music { Id = 2, Title = "Back in Black", Artist = "AC/DC",       Genre = "Rock", Year = 1980, Available = true }
        };

        // List of rentals
        public static List<Rental> Rentals { get; } = new List<Rental>();
    }
}
